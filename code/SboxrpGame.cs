
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// This is your game class. This is an entity that is created serverside when
/// the game starts, and is replicated to the client. 
/// 
/// You can use this to create things like HUDs and declare which player class
/// to use for spawned players.
/// </summary>
internal partial class SboxrpGame : Game
{
	public SboxrpGame()
	{
		if ( IsServer )
		{
			// Create the HUD
			_ = new SboxrpHud();
		}
	}

	/// <summary>
	/// A client has joined the server. Make them a pawn to play with
	/// </summary>
	public override void ClientJoined( Client client )
	{
		base.ClientJoined( client );

		var player = new SandboxPlayer( client );
		player.Respawn();

		client.Pawn = player;

		NetworkClientLogin( client );
	}

	public override void ClientDisconnect( Client cl, NetworkDisconnectionReason reason )
	{
		base.ClientDisconnect( cl, reason );

		Log.Info( $"{cl.Name} has disconnected" );
	}


	public override void DoPlayerSuicide( Client cl )
	{
		Log.Info( "No suicide allowed" );
	}
}
