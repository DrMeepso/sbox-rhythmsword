using Sandbox;
using System;
using System.Linq;
using System.Text.Json;

namespace RythemSword
{
	partial class RythemPlayer : Player
	{

		public bool isplaying;

		public override void Spawn()
		{
			isplaying = false;
			base.Spawn();
		}

		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );

			// Use WalkController for movement (you can make your own PlayerController for 100% control)
			Controller = new WalkController();

			// Use StandardPlayerAnimator  (you can make your own PlayerAnimator for 100% control)
			Animator = new StandardPlayerAnimator();

			// Use ThirdPersonCamera (you can make your own Camera for 100% control)
			Camera = new ThirdPersonCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			base.Respawn();
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );
		}

		public void SetupGame()
		{
			/*
			Setting up game
			*/

		}
	}
}
