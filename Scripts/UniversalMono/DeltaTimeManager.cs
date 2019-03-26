using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/Mono Actions/Delta Time Manager")]
	public class DeltaTimeManager : Action
	{
		public FloatVariable targetVariable;

		public override void Execute()
		{
			targetVariable.value = Time.deltaTime;
		}
	}
}