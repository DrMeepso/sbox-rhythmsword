using Sandbox;
using System.Linq;
using System;

namespace RhythmSword
{

	[Library( "Saber_Right", Description = "Player Saber Right" )]
	public partial class SaberRight : Prop
	{
		public override void Spawn()
		{
			SetModel( "models/hands/alyx_hand_right.vmdl" );
			base.Spawn();
		}
	}
}
