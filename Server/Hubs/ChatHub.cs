using Microsoft.AspNetCore.SignalR;
using System.Numerics;
using BomberGopnik.Shared;
namespace BomberGopnik.Server.Hubs;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;
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

        double playerTop = 50;
        double playerLeft = 50;
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

    public async Task MovePlayer(Player player, List<BrickWall> bricks, KeyboardEventArgs e)
    {
        switch (e.Code)
        {
            case "37":
                changeLocation(-5, 0, player, bricks);
                break;
            case "38":
                changeLocation(0, -5, player, bricks);
                break;
            case "39":
                changeLocation(5, 0, player, bricks);
                break;
            case "40":
                changeLocation(0, 5, player, bricks);
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
                bomb.placeBomb(player);
                BombManager.Addbomb(bomb);
                PlayerManager.Instance.IncrementScore(player, 5);
                Console.WriteLine(player.ConnectionId + " : " + PlayerManager.Instance.GetScore(player) +  " : " + player.Points);
                await Clients.All.SendAsync("PlayerPlacedBomb", bomb);
                await Clients.Others.SendAsync("AllBombs", BombManager.Bombs.Values.ToList());
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
    private void changeLocation(int X, int Y, Player player, List<BrickWall> bricks)

    {
        double valueX = player.Left + X;
        double valueY = player.Top + Y;
        bool legalMove = true;
        foreach (var brick in bricks)
        {
            /// Intervlas tarp startX <=  x  <= StartX + 6 and startY <=  Y  <= Starty    if sąlygą sukonstruoti
			/// 
            if (valueX >= brick.StartX && valueX <= brick.StartX + 6 && valueY >= brick.StartY && valueY <= brick.StartY + 6)
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
}