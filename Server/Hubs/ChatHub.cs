using Microsoft.AspNetCore.SignalR;
using System.Numerics;
using BomberGopnik.Shared;
namespace BomberGopnik.Server.Hubs;
using System.Timers;
using BomberGopnik.Client.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

public class ArenaHub : Hub, IArenaHub
{
    private readonly Random random = new Random();
    private readonly IHubContext<ArenaHub> _context;
    private Timer extraSpeedTimer;
    public ArenaHub(IHubContext<ArenaHub> hubContext)
    {
        _context = hubContext;
    }
    public async Task JoinArena(string name, string skin)
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


		string[] colors = { "#ffffff00", "#ff0000", "#00ff00", "#0000ff", "#ff00ff", "#00ffff" };
		string playerColor = colors[0];

        
        int playerTop = 50;
        int playerLeft = 50;
        int points = 0;
        
        
        var player = new Player(Context.ConnectionId, playerColor, playerTop, playerLeft, points, name, skin);

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

    public async Task SetName(string name)
    {
        PlayerManager.AddNames(name);
        await Clients.Caller.SendAsync("SetName", PlayerManager.Instance.GetNames());
    }
	public async Task MovePlayer(Player player, string arena, KeyboardEventArgs e)
	{
		if (e != null)
		{
			Arena tempArena = getArena(arena);
			//tempArena = cleanArena(tempArena);

			IMovement movement = CreateMovement(e);
			changeLocation(movement, player, tempArena);
			PlayerManager.EditPlayer(player);
			tempArena.players = PlayerManager.Instance.GetAllPlayers();

			await Clients.All.SendAsync("UpdatedArena", SerializeArena(tempArena));
		}
	}
    private async void RemoveSpeed(Player player)
    {
        await Task.Delay(2000);
        player.ExtraSpeed = true;
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

	public async Task PlaceBomb(Player player, string arena, KeyboardEventArgs e)
	{
		switch (e.Code)
		{
			case "32":

				Arena tempArena = getArena(arena);

				var bomb = new Bomb();
				bomb.Id = player.ConnectionId;
				bomb.SetState(new IdleStateBomb());


				bomb.placeBomb(player);
				await BombManager.Addbomb(bomb);
				tempArena.bombs.Add(bomb);

				PlayerManager.Instance.IncrementScore(player, 5);
				tempArena.players = PlayerManager.Players.Values.ToList();

				Console.WriteLine($"Padejo: {Context.ConnectionId}");
				await Clients.All.SendAsync("UpdatedArena", SerializeArena(tempArena));

				break;

			default: break;
		}

	}

	public async Task RemoveSpecialBomb(Player player, KeyboardEventArgs e)
	{
		Receiver receiver = new Receiver();
		ICommand command = new UndoAddSpecialBombCommand(receiver);

		Invoker invoker = new Invoker();
		switch (e.Code)
		{
			case "81":
				var bomb = new SpecialBomb();
				bomb.Id = player.ConnectionId;
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
	private void changeLocation(IMovement movement, Player player, Arena arena)
	{
        SpeedPoweerUp powerup;
        int valueX = player.Left + movement.Dx;
        int valueY = player.Top + movement.Dy;

        if (player.ExtraSpeed)
		{
            valueX = player.Left + (movement.Dx * 2);
            valueY = player.Top + (movement.Dy * 2);
        }


		//Console.WriteLine($"x:{player.Left + movement.Dx}  y:{player.Top + movement.Dy}");
		
		//keturios puses
		bool legalMove = (arena.grid[valueX/10, valueY/10] == null || arena.grid[valueX / 10, valueY / 10] is SpeedPoweerUp)
					  && (arena.grid[ (valueX + 5) / 10, (valueY + 5) / 10] == null || arena.grid[(valueX + 5) / 10, (valueY + 5) / 10] is SpeedPoweerUp);


        if (arena.grid[valueX / 10, valueY / 10] is SpeedPoweerUp || arena.grid[(valueX + 5) / 10, (valueY + 5) / 10] is SpeedPoweerUp)
        {
            powerup = (SpeedPoweerUp)arena.grid[valueX / 10, valueY / 10];

            arena.grid[valueX / 10, valueY / 10] = null;
            arena.grid[(valueX + 5) / 10, (valueY + 5) / 10] = null;
            arena.powerups[valueX / 10, valueY / 10] = 0;
            player.Visit(powerup);
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
		if (BombManager.GetBombs().Exists(n => n.Exploded && !n.viewed)) {
			Bomb bomb = BombManager.GetBombs().First(n => n.Exploded && !n.viewed);
			await _context.Clients.Client(bomb.Id!).SendAsync("AllBombs", BombManager.GetBombs());
		} 

	}

	public async Task HandleExplosion(string arena)
	{
		Arena tempArena = getArena(arena);
		Console.WriteLine($"Atejo: {Context.ConnectionId}");

		foreach (var bomb in BombManager.GetBombs()) { 

			if(bomb.Exploded && !bomb.viewed)
			{
				BombManager.setView(bomb);
				int i = bomb.StartX / 10;
				int j = bomb.StartY / 10;
				List<int[]> path = bomb.Path;
				int length = path.Count / 2;

				int minX = length, minY = length, maxX = length, maxY = length;

				if (i + length > 9) {
					maxX = 9 - i;
				}
				if (j + length > 9) {
					maxY = 9 - j;
				}
				if (i - length < 0) {
					minX = i;
				}
				if (j - length < 0) { 
					minY = j;
				}

				for (int x = length - minX; x <= length + maxX; x++) {
					for (int y = length - minY; y <= length + maxY; y++)
					{
						if (path[y][x] > 0) {
                            if (tempArena.grid[i - length + x, j - length + y] is Box)
                            {
								tempArena.powerups[i - length + x, j - length + y] = 1;
                            }
							if (tempArena.grid[i - length + x, j - length + y] is BrickWall) {
								continue;
							}
                            IStructure fire = new Fire();

							List<Player> damagedPlayers = tempArena.players.FindAll(n => Math.Abs(n.Left / 10 - i + length - x) == 0 && Math.Abs(n.Top / 10 - j + length - y) == 0);

							damagedPlayers.ForEach(async player =>
							{
								await _context.Clients.Client(player.ConnectionId!).SendAsync("GameOver");
								PlayerManager.RemovePlayer(player);
							});

							tempArena.grid[i - length + x, j - length + y] = fire;
                        }
					}
				}
				Console.WriteLine($"Apskaiciavo: {Context.ConnectionId}");
			}
		}

		tempArena.bombs = BombManager.GetBombs();
		tempArena.players = PlayerManager.Instance.GetAllPlayers();

		await Clients.All.SendAsync("UpdatedArena", SerializeArena(tempArena));
		Console.WriteLine($"Issiunte: {Context.ConnectionId}");
	}

    private Arena getArena(string arena) => JsonConvert.DeserializeObject<Arena>(arena, new JsonSerializerSettings()
	{
		TypeNameHandling = TypeNameHandling.Auto
	});

	private string SerializeArena(Arena arena) => JsonConvert.SerializeObject(arena, new JsonSerializerSettings()
	{
		TypeNameHandling = TypeNameHandling.Auto
	});
	public override async Task OnDisconnectedAsync(Exception? exception)
	{
		if (PlayerManager.Players.ContainsKey(Context.ConnectionId))
		{
			PlayerManager.Players.Remove(Context.ConnectionId);
		}

		await Clients.Others.SendAsync("UpdatedArena", PlayerManager.Players.Values.ToList());

		await base.OnDisconnectedAsync(exception);

    }
    public async Task LoadExplosionGraphics()
    {
        // Notify clients to load explosion graphics
        await Clients.All.SendAsync("ExecuteJavaScript");
    }

}