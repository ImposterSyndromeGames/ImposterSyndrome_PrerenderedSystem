using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SO;

namespace AKNew
{
	[CreateAssetMenu(menuName = "ClassicPrerenderActions/Cases/Classic Prerender Switch")]
	public class ClassicPrerenderSwitch : ClassicPrerenderActions
	{
		[Tooltip("Only reason there is a FOV variables is if I want to implement orthographic 3D at some stage")]
		public BoolVariable playAnimationEvent;

		public void SetRI(Camera c, RawImage ri, Classic_Container cs, ScrollRect sr)
		{
			// For All.
			ri.rectTransform.sizeDelta = new Vector2(c.scaledPixelWidth, c.scaledPixelHeight);

			// For Static Image.
			if (cs.isAnimatedContainer == false)
			{
				ri.material.SetFloat("_Near", cs.FloatForNearClip);
				ri.material.SetFloat("_Far", cs.FloatForFarClip);
				
				ri.material.SetTexture("_RenderedTex", cs.RenderedTextureBoi);
				ri.material.SetTexture("_DepthTex", cs.DepthTextureBoi);
			}

			// For Animated and Non-Transition Animation.
			if (cs.isAnimatedContainer == true && cs.containsTransitionScene == false)
			{
				ri.material.SetFloat("_Near", cs.FloatForNearClip);
				ri.material.SetFloat("_Far", cs.FloatForFarClip);
			}

			sr.viewport.sizeDelta = new Vector2(Screen.width, Screen.height);
		}

		public void SetC(Camera c, RawImage ri, Classic_Container cs)
		{
			// For All.
			c.transform.localPosition = new Vector3(0, 0, 0);
			c.transform.localEulerAngles = new Vector3(0, 0, 0);

			c.orthographic = false;

			// For Static and Animated BUT Non-Transition Animation.
			if (cs.containsTransitionScene == false)
			{
				c.nearClipPlane = cs.FloatForNearClip;
				c.farClipPlane = cs.FloatForFarClip;

				c.fieldOfView = cs.FOVValue;
			}
		}

		public void SetCHolder(RawImage ri, Classic_Container cs, GameObject cH)
		{
			// For Static and Animated BUT Non-Transition Animation.
			if (cs.containsTransitionScene == false)
			{
				cH.transform.localPosition = cs.CameraPosition;
				cH.transform.eulerAngles = cs.CameraRotation;
			}
		}

		public override void UpdateClassicScene(Camera c, RawImage ri, Classic_Container cs, ScrollRect sr, Camera oc, GameObject cH)
		{
			if (cs.isAnimatedContainer == true)
			{
				playAnimationEvent.value = true;
			}
			else
			{
				playAnimationEvent.value = false;
			}
		}
	}
}