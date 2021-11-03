using Sandbox;
using System;
using System.Linq;
using System.Text.Json;


namespace RythemSword
{
	public partial class RythemGame : Sandbox.Game
	{

		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			// Create a pawn and assign it to the client.
			var player = new RythemPlayer();
			client.Pawn = player;

			player.Respawn();
		}

		[ServerCmd( "lookup" )]
		public void lookup( String songname )
		{

		}
	}
}
