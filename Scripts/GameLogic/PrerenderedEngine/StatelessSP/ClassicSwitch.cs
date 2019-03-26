using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SA;
using SO;

namespace AKNew
{
	[CreateAssetMenu(menuName = "ClassicActions/Cases/Switch Camera Logic")]
	public class ClassicSwitch : ClassicActions
	{
		//public InputAxis horizontalAxis;
		//public InputAxis verticalAxis;
		//public InputAxis middleWheelAxis;
		public Vector2 currentAnchoredPosition;// = new Vector2(0, 0);

		public float mouseAxis;
		public float tempVar;

		public override void ExecuteClassic(Camera c, RawImage ri, Classic_Container cs, GameObject cH)
		{
			
		}
	}
}