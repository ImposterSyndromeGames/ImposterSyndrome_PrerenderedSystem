using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace AKNew
{
	public class ColliderSwitch : MonoBehaviour
	{
		public Classic_Container classicContainerToSwitchTo;
		public ClassicContainerVariable classicContainerVariableFromHook;
		public BoolVariable updateSceneBool;
		public BoolVariable animUpdate;
		private ClassicActionHook GetActionHook;
		/*
		public void OnTriggerEnter(Collider c)
		{
			
			GetActionHook = GameObject.FindObjectOfType<ClassicActionHook>();
			Debug.Log("Action Hook: " + GetActionHook);

			GetActionHook.UpdateColliderTransition(classicContainerToSwitchTo);
		}
		*/

		public void OnTriggerEnter(Collider c)
		{
			if (classicContainerVariableFromHook.value.isAnimatedContainer == false)
			{
				if (classicContainerToSwitchTo != classicContainerVariableFromHook.value)
				{
					classicContainerVariableFromHook.value = classicContainerToSwitchTo;
					updateSceneBool.value = true;
				}
				else
				{
					Debug.Log("We are already in this Static scene!");
				}
			}
			else
			{
				if (classicContainerToSwitchTo != classicContainerVariableFromHook.value)
				{
					animUpdate.value = false;
					StopAllCoroutines();

					classicContainerVariableFromHook.value = classicContainerToSwitchTo;
					updateSceneBool.value = true;
				}
				else
				{
					Debug.Log("We are already in this Animated scene!");
				}
			}

			// Reason why we don't set this as ref.value.isAnimatedContainer == false here is because if scene 
			// has been updated from above then it may go through here.
			/*
			if (animUpdate.value == true)
			{
				if (classicContainerToSwitchTo != classicContainerVariableFromHook.value)
				{
					animUpdate.value = false;
					StopAllCoroutines();

					classicContainerVariableFromHook.value = classicContainerToSwitchTo;
					updateSceneBool.value = true;
				}
				else
				{
					Debug.Log("We are already in this Animated scene!");
				}
			}*/
		}
	}
}