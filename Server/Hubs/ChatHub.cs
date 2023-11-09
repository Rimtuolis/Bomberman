using Microsoft.AspNetCore.SignalR;
using System.Numerics;
using BomberGopnik.Shared;
namespace BomberGopnik.Server.Hubs;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

public class ArenaHub : Hub
{
    private readonly Random random = new Random();
    public async Task JoinArena()
    {
        Player? existingPlayer = null;

        if (PlayerManager.Players.ContainsKey(Context.ConnectionId))
        {
            existingPlayer = PlayerManager.Players[Context.ConnectionId];
        }

        if (existingPlayer != null)
        {
            return;
        }

        string[] colors = { "#ff0000", "#00ff00", "#0000ff", "#ff00ff", "#00ffff" };
        string playerColor = colors[random.Next(0, colors.Length)];

        int playerTop = 50;
		int playerLeft = 50;

        var player = new Player(Context.ConnectionId, playerColor, playerTop, playerLeft);
        PlayerManager.AddPlayer(player);


        await Clients.Caller.SendAsync("AssignPlayer", PlayerManager.Players.Values.ToList());
        await Clients.Others.SendAsync("PlayerJoined", player);
    }

    public async Task PauseArena(Player player)
    {
        await Clients.All.SendAsync("PauseArena", player);
    }

    public async Task MovePlayer(Player player, List<BrickWall> bricks, KeyboardEventArgs e)
    {
		if (e != null) {
			IMovement movement = CreateMovement(e);
			changeLocation(movement, player, bricks);

			PlayerManager.EditPlayer(player);

			await Clients.All.SendAsync("PlayerMoved", PlayerManager.Players.Values.ToList());
		}
    }

	private IMovement CreateMovement(KeyboardEventArgs e)
	{
		if (IsArrowKey(e.Code))
		{
			return new ArrowKeyMovement(e);
		}

    	return new WASDKeyMovement(e);
	}

	bool IsArrowKey(String e) => e.Equals("37") || e.Equals("38") || e.Equals("39") || e.Equals("40");

	public async Task PlaceBomb(Player player, Bomb bomb, KeyboardEventArgs e)
    {
        switch (e.Code)
        {
            case "32":
                placeBomb(player, bomb);
                BombManager.Addbomb(bomb);
                await Clients.Caller.SendAsync("PlayerPlacedBomb", bomb);
                await Clients.Others.SendAsync("AllBombs", BombManager.Bombs.Values.ToList());
                break;

            default: break;
        }
    }
    private void changeLocation(IMovement movement, Player player, List<BrickWall> bricks)
    {
        int valueX = player.Left + movement.Dx;
        int valueY = player.Top + movement.Dy;
        bool legalMove = true;
        foreach (var brick in bricks)
        {

            if (valueX >= brick.GetStartX() && valueX <= brick.GetStartX() + 6 && valueY >= brick.GetStartY() && valueY <= brick.GetStartY() + 6 ||
                valueX >= brick.GetStartX() - 6 && valueX <= brick.GetStartX() && valueY >= brick.GetStartY() - 6 && valueY <= brick.GetStartY())
            {
                legalMove = false;
            }

        }
        switch (valueX)
        {
            case < 6:
                player.Left = 6;
                break;
            case > 94:
                player.Left = 94;
                break;
            default:
                if (legalMove) player.Left = valueX;
                break;
        }
        switch (valueY)
        {
            case < 6:
                player.Top = 6;
                break;
            case > 94:
                player.Top = 94;
                break;
            default:
                if (legalMove) player.Top = valueY;
                break;
        }
    }
    private void placeBomb(Player player, Bomb bomb)
    {
        ///TODO handle placing on square
        bomb.StartX = player.Left;
        bomb.StartY = player.Top;
    }
}