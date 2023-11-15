﻿using Microsoft.AspNetCore.SignalR;
using System.Numerics;
using BomberGopnik.Shared;
namespace BomberGopnik.Server.Hubs;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

public class ArenaHub : Hub, IArenaHub
{
    private readonly Random random = new Random();
    private readonly IHubContext<ArenaHub> _context;
    public ArenaHub(IHubContext<ArenaHub> hubContext) {
        _context = hubContext;
    }
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
        int points = 0;

        var player = new Player(Context.ConnectionId, playerColor, playerTop, playerLeft, points);
        
        PlayerManager.AddPlayer(player);
        var playerObserver = new PlayerObserver(player);

        await Clients.Caller.SendAsync("AssignPlayer", PlayerManager.Players.Values.ToList());
        await Clients.Others.SendAsync("PlayerJoined", player, playerObserver);
        await Clients.All.SendAsync("ObserverJoined", player);
    }

    public async Task PauseArena(PlayerManagerSubject subject, Player player, List<Player> pausedObservers)
    {
        await Clients.All.SendAsync("PauseArena", subject, player, pausedObservers);
    }

    public async Task MovePlayer(Player player, string bricks, KeyboardEventArgs e)
    {
		if (e != null) {
            Console.WriteLine(player.Left + " - " + player.Top) ;
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

                bomb.placeBomb(player);
                await BombManager.Addbomb(bomb);
                Console.WriteLine(bomb.StartX + " - " + bomb.StartY);
                PlayerManager.Instance.IncrementScore(player, 5);
                Console.WriteLine(player.ConnectionId + " : " + PlayerManager.Instance.GetScore(player) +  " : " + player.Points);
                await Clients.All.SendAsync("PlayerPlacedBomb", bomb);
                await Clients.All.SendAsync("PlayerMoved", PlayerManager.Players.Values.ToList());

                break;

            default: break;
        }
        
    }

    public async Task RemoveSpecialBomb(Player player, SpecialBomb bomb, KeyboardEventArgs e)
    {
        Receiver receiver = new Receiver();
        ICommand command = new UndoAddSpecialBombCommand(receiver);

        Invoker invoker = new Invoker();
        switch (e.Code)
        {
            case "81":
                invoker.SetCommand(command);
                invoker.ExecuteCommand(bomb);
                await Clients.Caller.SendAsync("PlayerRemovedSpecialBomb", bomb);
                await Clients.All.SendAsync("AllSpecialBombs", Detonator.SpecialBombs.Values.ToList());
                break;

            default: break;
        }
    }

    public async Task PlaceSpecialBomb(Player player, SpecialBomb bomb, KeyboardEventArgs e)
    {
        Receiver receiver = new Receiver();
        ICommand command = new AddSpecialBombCommand(receiver);

        Invoker invoker = new Invoker();
        switch (e.Code)
        {
            case "69":
                bomb.placeBomb(player);
                invoker.SetCommand(command);
                invoker.ExecuteCommand(bomb);
                await Clients.Caller.SendAsync("PlayerPlacedSpecialBomb", bomb);
                await Clients.Others.SendAsync("AllSpecialBombs", Detonator.SpecialBombs.Values.ToList());
                break;

            default: break;
        }
    }
    private void changeLocation(IMovement movement, Player player, string jsonBricks)
    {
        int valueX = player.Left + movement.Dx;
        int valueY = player.Top + movement.Dy;
        bool legalMove = true;
        List<BrickWall> bricks = JsonConvert.DeserializeObject<List<BrickWall>>(jsonBricks);
        foreach (var brick in bricks)
        {

        /*    if (valueX >= brick.GetStartX() && valueX <= brick.GetStartX() + 10 && valueY >= brick.GetStartY() && valueY <= brick.GetStartY() + 10 ||
                valueX >= brick.GetStartX() - 10 && valueX <= brick.GetStartX() && valueY >= brick.GetStartY() - 10 && valueY <= brick.GetStartY())
            {
                legalMove = false;
            }*/

        }
        switch (valueX)
        {
            case < 0:
                player.Left = 0;
                break;
            case > 90:
                player.Left = 90;
                break;
            default:
                if (legalMove) player.Left = valueX;
                break;
        }
        switch (valueY)
        {
            case < 0:
                player.Top = 0;
                break;
            case > 90:
                player.Top = 90;
                break;
            default:
                if (legalMove) player.Top = valueY;
                break;
        }
    }

    public async Task SendBombsAll()
    {
       
        //Console.WriteLine(BombManager.GetBombs().Count);
        await _context.Clients.All.SendAsync("AllBombs", BombManager.GetBombs());
       
    }
}