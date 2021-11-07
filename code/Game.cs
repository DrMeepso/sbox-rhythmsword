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
			base.ClientDisconnect( cl, reason );

			var dcplayer = cl.Pawn as RhythmPlayer;
			dcplayer.LeftHand.Delete();
			dcplayer.RightHand.Delete();
		}

		[ServerCmd( "lookup" )]
		public void lookup( String songname )
		{

		}
	}
}
