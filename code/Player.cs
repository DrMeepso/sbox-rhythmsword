using Sandbox;
using System;
using System.Linq;
using System.Text.Json;

namespace RhythmSword
{
	partial class RhythmPlayer : Player
	{
		public bool isplaying;
		public Entity SaberRightLocal;
		public Entity SaberLeftLocal;
		public Game Localgame;

		public override void Spawn()
		{
			isplaying = false;
			base.Spawn();
			Log.Info( "Player Spawned" );
			Localgame = RhythmGame.Current;

			if ( VR.Enabled )
			{
				SaberRightLocal = new SaberRight()
				{
					Position = Input.VR.RightHand.Transform.Position,
					Rotation = Input.VR.RightHand.Transform.Rotation
				};
				SaberLeftLocal = new SaberLeft()
				{
					Position = Input.VR.LeftHand.Transform.Position,
					Rotation = Input.VR.LeftHand.Transform.Rotation
				};
			}
		}

		public override void Respawn()
		{

			SetModel( "models/citizen/citizen.vmdl" );

			// Use WalkController for movement (you can make your own PlayerController for 100% control)
			//Controller = new WalkController();

			// Use StandardPlayerAnimator  (you can make your own PlayerAnimator for 100% control)
			//Animator = new StandardPlayerAnimator();

			// Use ThirdPersonCamera (you can make your own Camera for 100% control)
			Camera = new FirstPersonCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = false;

			base.Respawn();

			Position = new Vector3( 0, 0, 5 );
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			if ( VR.DashboardIsOpen )
			{
				// Pause song when this is true

			}
			if (VR.Enabled )
			{
				SaberRightLocal.Position = Input.VR.RightHand.Transform.Position;
				SaberLeftLocal.Position = Input.VR.LeftHand.Transform.Position;
			}
		}

		public override void TakeDamage( DamageInfo info )
		{
			//base.TakeDamage( info );
		}
		public override void OnKilled()
		{
			//base.OnKilled();
		}
	}
}
