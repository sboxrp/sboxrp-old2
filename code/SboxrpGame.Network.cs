using Sandbox.Internal;
using System.Threading.Tasks;
using System.Text.Json;
using Sandbox;
using System.Collections.Generic;
using System.Linq;
using System.IO;


internal partial class SboxrpGame
{
	[Net]
	public bool Connected { get; set; }

	private static WebSocket WebSocket = new WebSocket();

	public static async Task Post( string controller, string jsonData )
	{


		/*var msg = new GameMessage()
		{
			Id = ++MessageIdAccumulator,
			Controller = controller,
			Message = jsonData,
		};

		await WebSocket.Send( JsonSerializer.Serialize( msg, JsonOptions ) );*/
	}

	private async void NetworkServerLogin()
	{
		Host.AssertServer();

		if ( !Global.IsDedicatedServer ) return;

		var pkg = await Package.Fetch( Global.MapName, true );
		var mapTitle = pkg?.Title ?? string.Empty;

		await Post( "awre", "awerawere" );

		/*var msg = new ServerLogin()
		{
			SteamId = Global.ServerSteamId,
			ServerName = string.Empty, // no way to grab this yet?
			MapIdent = Global.MapName,
			MapTitle = mapTitle,
			CourseType = CourseType
		};

		await Backend.Post<bool>( "server/login", msg.Serialize() );*/
	}

	private async void NetworkClientLogin( Client client )
	{
		Host.AssertServer();

		//if ( !Global.IsDedicatedServer ) return;

		Log.Info( "The player should be authenticated now, their id is: " + client.PlayerId );

		await WebSocket.Connect( "ws://localhost:3000" );

		await WebSocket.Send( "hello there" );

		Log.Info( "Posted that message" );

		/*var msg = new ClientLogin()
		{
			ServerSteamId = (long)Global.ServerSteamId,
			Name = client.Name,
			PlayerId = client.PlayerId,
			MapIdent = Global.MapName
		};

		await Backend.Post<bool>( "player/login", msg.Serialize() );*/
	}

	[Event.Tick.Server]
	private void OnTick() => Connected = true;
}

