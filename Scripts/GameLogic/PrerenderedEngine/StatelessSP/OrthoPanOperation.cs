using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SO;

namespace AKNew
{
	[CreateAssetMenu(menuName = "OrthoActions/Switch Actions/Pan Operation")]
	public class OrthoPanOperation : OrthoSwitch
	{
		public FloatVariable delta;

		public override void Execute(Camera c, RawImage ri, IsometricOrtho_Container scs, GameObject cH)
		{
			if (panBool.value == true)
			{
				cameraTransEvent.value = false;
				Debug.Log("Pan Operation Is On!");

				if (horizontalAxis.value < -0.15)
				{
					ri.rectTransform.anchoredPosition += new Vector2(Mathf.Lerp(0, -horizontalAxis.value * 25, delta.value * 100), 0); //Original delta = Time.deltaTime * 100
					SetOrthoVector3(ri, c, scs);
				}

				if (horizontalAxis.value > 0.15)
				{
					ri.rectTransform.anchoredPosition -= new Vector2(Mathf.Lerp(0, horizontalAxis.value * 25, delta.value * 100), 0);
					SetOrthoVector3(ri, c, scs);
				}

				if (verticalAxis.value < -0.15)
				{
					ri.rectTransform.anchoredPosition += new Vector2(0, Mathf.Lerp(0, -verticalAxis.value * 25, delta.value * 100));
					SetOrthoVector3(ri, c, scs);
				}

				if (verticalAxis.value > 0.15)
				{
					ri.rectTransform.anchoredPosition -= new Vector2(0, Mathf.Lerp(0, verticalAxis.value * 25, delta.value * 100));
					SetOrthoVector3(ri, c, scs);
				}
			}
			else
			{
				//cameraTransEvent.value = true;
				Debug.Log("Pan Operation Is Off!");
			}

			// No clue what this does...
			//base.Execute(c, ri, scs);

			
		}
	}
}