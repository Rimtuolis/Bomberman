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

		string[] colors = { "#ff0000", "#00ff00", "#0000ff", "#ffff00", "#ff00ff", "#00ffff" };
		string playerColor = colors[random.Next(0, colors.Length)];

		double playerTop = 50;
		double playerLeft = 50;

		var player = new Player(Context.ConnectionId, playerColor, playerTop, playerLeft);
		PlayerManager.AddPlayer(player);

		await Clients.Caller.SendAsync("AssignPlayer", PlayerManager.Players.Values.ToList());
		await Clients.Others.SendAsync("PlayerJoined", player);
	}
	public async Task MovePlayer(Player player, KeyboardEventArgs e)
	{
		switch (e.Code)
		{
			case "37":
				changeLocation(-5, 0, player);
				break;
			case "38":
				changeLocation(0, -5, player);
				break;
			case "39":
				changeLocation(5, 0, player);
				break;
			case "40":
				changeLocation(0, 5, player);
				break;

			default: break;
		}
		PlayerManager.EditPlayer(player);

		await Clients.All.SendAsync("PlayerMoved", PlayerManager.Players.Values.ToList());
	}
	public async Task PlaceBomb(Player player, Bomb bomb, KeyboardEventArgs e)
	{
		switch (e.Code)
		{
			case "32":
				placeBomb(player, bomb);
				break;

			default: break;
		}
        PlayerManager.EditPlayer(player);
		await Clients.All.SendAsync("PlayerPlacedBomb", PlayerManager.Players.Values.ToList());
    }
	private void changeLocation(int X, int Y, Player player)
	{
		double valueX = player.Left + X;
		double valueY = player.Top + Y;

		switch (valueX)
		{
			case < 6:
				player.Left = 6;
				break;
			case > 94:
				player.Left = 94;
				break;
			default:
				player.Left = valueX;
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
				player.Top = valueY;
				break;
		}
	}
	private void placeBomb(Player player, Bomb bomb)
	{
		bomb.StartX = player.Left;
		bomb.StartY = player.Top;
	}
}