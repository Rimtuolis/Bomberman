using Microsoft.AspNetCore.SignalR;
using System.Numerics;
using BomberGopnik.Shared;
namespace BomberGopnik.Server.Hubs;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

public class ArenaHub : Hub
{
	private readonly List<Player> players = new List<Player>();
	private readonly Random random = new Random();
	public async Task JoinArena()
	{
		var existingPlayer = players.FirstOrDefault(p => p.ConnectionId == Context.ConnectionId);
		if (existingPlayer != null)
		{
			return; 
		}

		string[] colors = { "#ff0000", "#00ff00", "#0000ff", "#ffff00", "#ff00ff", "#00ffff" };
		string playerColor = colors[random.Next(0, colors.Length)];

		double playerTop = 50;
		double playerLeft = 50;

		var player = new Player(Context.ConnectionId, playerColor, playerTop, playerLeft);

		players.Add(player);

		await Clients.Caller.SendAsync("AssignPlayer", player);
		await Clients.Others.SendAsync("PlayerJoined", player);
	}
}