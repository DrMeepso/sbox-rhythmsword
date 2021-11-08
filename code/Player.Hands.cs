using Sandbox;
using System;
using System.Linq;
using System.Text.Json;

namespace RhythmSword
{
	partial class RhythmPlayer
	{
		[Net, Predicted]
		public AnimEntity LeftHand { get; set; }
		[Net, Predicted]
		public AnimEntity RightHand { get; set; }
		protected Vector3 LeftPosOffset => LeftHand.Rotation.Backward * 4f;
		protected Vector3 RightPosOffset => RightHand.Rotation.Backward * 4f;
		protected Rotation RotOffset => Rotation.FromPitch( 65 );

		public void CreateVRHands()
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

		public void UpdateHands() 
		{
			if ( !Input.VR.IsActive || !IsServer ) return;

			LeftHand.Position = (Input.VR.LeftHand.Transform.Position + LeftPosOffset);
			LeftHand.Rotation = Input.VR.LeftHand.Transform.Rotation;

			RightHand.Position = (Input.VR.RightHand.Transform.Position + RightPosOffset);
			RightHand.Rotation = Input.VR.RightHand.Transform.Rotation;
		}
	}
}
