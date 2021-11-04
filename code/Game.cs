using Sandbox;
using System;
using System.Linq;
using System.Text.Json;

namespace RhythmSword
{
	public partial class RhythmGame : Sandbox.Game
	{

		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new RhythmPlayer();
			client.Pawn = player;
			player.Respawn();

			if( client.IsUsingVr == false )
			{
				//Display VR Warning
				Log.Info( "Player is not in VR" );

			}
		}

		public override void ClientDisconnect( Client cl, NetworkDisconnectionReason reason )
		{
			var dcplayer = cl.Pawn as RhythmPlayer;
			dcplayer.SaberLeftLocal.Delete();
			dcplayer.SaberRightLocal.Delete();

			base.ClientDisconnect( cl, reason );
		}

		[ServerCmd( "lookup" )]
		public void lookup( String songname )
		{

		}
	}
}
