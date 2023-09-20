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
		var existingPlayer = PlayerManager.Players.FirstOrDefault(p => p.ConnectionId == Context.ConnectionId);
		if (existingPlayer != null)
		{
			return; 
		}
		Console.WriteLine("BYBYS");
		string[] colors = { "#ff0000", "#00ff00", "#0000ff", "#ffff00", "#ff00ff", "#00ffff" };
		string playerColor = colors[random.Next(0, colors.Length)];

		double playerTop = 50;
		double playerLeft = 50;

		var player = new Player(Context.ConnectionId, playerColor, playerTop, playerLeft);

		PlayerManager.AddPlayer(player);

		await Clients.Caller.SendAsync("AssignPlayer", PlayerManager.Players);
		await Clients.Others.SendAsync("PlayerJoined", player);
	}
	public async Task MovePlayer(Player player) {
		Console.WriteLine("aborigebnas");
		PlayerManager.EditPlayer(player);
		await Clients.All.SendAsync("PlayerMoved", PlayerManager.Players);
	}

}