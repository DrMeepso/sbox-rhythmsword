using Sandbox;
using System;
using System.Linq;
using System.Text.Json;

namespace RhythmSword
{
	partial class RhythmPlayer : Player
	{
		public bool isplaying;
		[Net, Predicted]
		public AnimEntity LeftHand { get; set; }
		[Net, Predicted]
		public AnimEntity RightHand { get; set; }
		public Game Localgame;

		protected Vector3 LeftPosOffset => LeftHand.Rotation.Backward * 4f;
		protected Vector3 RightPosOffset => RightHand.Rotation.Backward * 4f ;
		protected Rotation RotOffset => Rotation.FromPitch( 65 );

		public override void Spawn()
		{
			isplaying = false;
			base.Spawn();
			Log.Info( "Player Spawned" );
			Localgame = RhythmGame.Current;


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

			if ( Input.VR.IsActive )
			{
				// Create Hands!
				if ( LeftHand == null )
				{
					LeftHand = new AnimEntity();
					LeftHand.SetModel( "models/hands/alyx_hand_left.vmdl" );
					LeftHand.Scale = 1f;
					//LeftHand.SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
					LeftHand.SetInteractsAs( CollisionLayer.Debris );

					Log.Info( "Made a new Left Hand!" );
				}
				if ( RightHand == null )
				{
					RightHand = new AnimEntity();
					RightHand.SetModel( "models/hands/alyx_hand_right.vmdl" );
					RightHand.Scale = 1f;
					//RightHand.SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
					RightHand.SetInteractsAs( CollisionLayer.Debris );

					Log.Info( "Made a new Right Hand!" );
				}
			}

		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			if ( VR.DashboardIsOpen )
			{
				// Pause song when this is true

			}

			if ( !Input.VR.IsActive || !IsServer ) return;

			LeftHand.Position = (Input.VR.LeftHand.Transform.Position + LeftPosOffset);
			LeftHand.Rotation = Input.VR.LeftHand.Transform.Rotation;

			RightHand.Position = (Input.VR.RightHand.Transform.Position + RightPosOffset);
			RightHand.Rotation = Input.VR.RightHand.Transform.Rotation;
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
