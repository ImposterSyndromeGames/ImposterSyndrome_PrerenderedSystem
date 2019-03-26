using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;
using AKNew;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/Mono Actions/Input Manager")]
	public class InputManager : Action
	{
		public FloatVariable horizontal;
		public FloatVariable vertical;
		public BoolVariable jump;

		public StateManagerVariable playerStates;
		public ActionBatch inputUpdateBatch;

		//public PreRenderedLogicSO PLMS;
		//public StateManagerVariable playerStateManager;

		public override void Execute()
		{
			inputUpdateBatch.Execute();
			/*
			if (playerStates.value != null)
			{
				playerStates.value.movementVariables.horizontal = horizontal.value;
				playerStates.value.movementVariables.vertical = vertical.value;

				float moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal.value) + Mathf.Abs(vertical.value));
				playerStates.value.movementVariables.moveAmount = moveAmount;

				playerStates.value.isJumping = jump.value;*/
				/*
				if (jump.value == true)
				{
					
				}*/
				/*
			}
			else
			{*/
				/*playerStates.value.movementVariables.horizontal = horizontal.value;
				playerStates.value.movementVariables.vertical = vertical.value;

				float moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal.value) + Mathf.Abs(vertical.value));
				playerStates.value.movementVariables.moveAmount = moveAmount;*/
				//playerStates.value = playerStateManager.value;
			//}
			
		}

	}
}