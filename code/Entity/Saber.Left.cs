using Sandbox;
using System.Linq;
using System;

namespace RhythmSword
{

	[Library( "Saber_Left", Description = "Player Saber Left" )]
	public partial class SaberLeft : Prop
	{
		public override void Spawn()
		{
			SetModel( "models/hands/alyx_hand_left.vmdl" );
			base.Spawn();
		}
	}
}
