using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;
using AKNew;

namespace SA
{
    public class OnEnable_AssignTransform : MonoBehaviour
    {
        public TransformVariable transformVariable;

		private void OnEnable()
		{
			transformVariable.value = this.transform;
			//Destroy(this);
		}

		public void Update()
		{
			if (transformVariable.value == null)
			{
				transformVariable.value = this.transform;
				Debug.Log("The State Manager has been Updated (From OnEnable_AssignStateManager)");
			}
		}

	}
}
