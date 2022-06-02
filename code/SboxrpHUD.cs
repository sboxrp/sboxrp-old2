using Sandbox;
using Sandbox.UI;


/// <summary>
/// This is the HUD entity. It creates a RootPanel clientside, which can be accessed
/// via RootPanel on this entity, or Local.Hud.
/// </summary>
[Library]
public partial class SboxrpHud : HudEntity<RootPanel>
{
	public SboxrpHud()
	{
		if ( !IsClient )
			return;

		RootPanel.StyleSheet.Load( "SboxrpHUD.scss" );


		RootPanel.AddChild<ChatBox>();
		RootPanel.AddChild<VoiceList>();
		RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();
		RootPanel.AddChild<Health>();
		RootPanel.AddChild<InventoryBar>();
		RootPanel.AddChild<CurrentTool>();
		RootPanel.AddChild<SpawnMenu>();
		RootPanel.AddChild<Crosshair>();
	}
}
