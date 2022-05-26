using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal partial class SboxrpGame
{
	[Net]
	public bool Connected { get; set; }

	private async void NetworkServerLogin()
	{
		Host.AssertServer();

		if (!Global.IsDedicatedServer) return;

		var pkg = await Package.Fetch(Global.MapName, true);
		var mapTitle = pkg?.Title ?? string.Empty;

		var msg = new ServerLogin()
		{
			SteamId = Global.ServerSteamId,
			ServerName = string.Empty, // no way to grab this yet?
			MapIdent = Global.MapName,
			MapTitle = mapTitle,
			CourseType = CourseType
		};

		await Backend.Post<bool>("server/login", msg.Serialize());
	}

	private async void NetworkClientLogin(Client client)
	{
		Host.AssertServer();

		if (!Global.IsDedicatedServer) return;

		var msg = new ClientLogin()
		{
			ServerSteamId = (long)Global.ServerSteamId,
			Name = client.Name,
			PlayerId = client.PlayerId,
			MapIdent = Global.MapName
		};

		await Backend.Post<bool>("player/login", msg.Serialize());
	}

	[Event.Tick.Server]
	private void OnTick() => Connected = Backend.Connected;
}

