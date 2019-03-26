using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SO;

namespace AKNew
{
	[CreateAssetMenu(menuName = "OrthoPrerenderActions/Cases/Ortho Prerender Switch")]
	public class OrthoPrerenderSwitch : OrthoPrerenderActions
	{
		public BoolVariable playAnimationEvent;

		public void SetRI(Camera c, RawImage ri, IsometricOrtho_Container scs, ScrollRect sr)
		{
			
			if (scs.isAnimated == false)
			{
				ri.material.SetFloat("_Near", scs.FloatForNearClip);
				ri.material.SetFloat("_Far", scs.FloatForFarClip);
				//Debug.Log("Nice: " + (((2 * c.scaledPixelWidth) / 1280.0f) - 1.0f));

				// This works for texture of 2560, scalar is 1.0f, for texture of 5120, scalar is 2.0f
				ri.rectTransform.sizeDelta = new Vector2(scs.widthFromTexture * scs.multiplierFromTexture, scs.heightFromTexture * scs.multiplierFromTexture);
				// this works for scaling (WORK ON THIS LATER)    //ri.rectTransform.sizeDelta = new Vector2(scs.widthFromTexture * ((c.scaledPixelWidth) / 960.0f) / scs.rectSizeScalar, scs.heightFromTexture * ((c.scaledPixelHeight) / 540.0f) / scs.rectSizeScalar); // For 1920x1080
				//ri.rectTransform.sizeDelta = new Vector2(scs.widthFromTexture * 1.333f, scs.heightFromTexture * 1.333f); // For 1280x720
				//ri.rectTransform.sizeDelta = new Vector2(scs.widthFromTexture * (((2 * c.scaledPixelWidth ) / 1280.0f) - 1.0f), scs.heightFromTexture * (((2 * c.scaledPixelHeight) / 720.0f) - 1.0f));

				ri.material.SetTexture("_RenderedTex", scs.renderedTexture);
				ri.material.SetTexture("_DepthTex", scs.depthTexture);
			}

			if (scs.isAnimated == true)
			{
				ri.material.SetFloat("_Near", scs.FloatForNearClip);
				ri.material.SetFloat("_Far", scs.FloatForFarClip);

				ri.rectTransform.sizeDelta = new Vector2(scs.widthFromTexture * scs.multiplierFromTexture, scs.heightFromTexture * scs.multiplierFromTexture);
			}

			sr.viewport.sizeDelta = new Vector2(Screen.width, Screen.height);
			
		}

		public void SetC(Camera c, RawImage ri, IsometricOrtho_Container scs)
		{
			c.nearClipPlane = scs.FloatForNearClip;
			c.farClipPlane = scs.FloatForFarClip;

			c.transform.localEulerAngles = new Vector3(0, 0, 0);

			c.orthographic = true;

			//float a1 = scs.multiplierFromTexture
			//c.orthographicSize = 5.265f;
			//c.orthographicSize = (scs.orthoSizeFromTexture - (scs.orthoSizeFromTexture / 4.0f)); //(1280.0f / (1920.0f - 960.0f)));
			//c.orthographicSize = 5.265f;
			//c.orthographicSize = scs.orthoSizeFromTexture * ((c.scaledPixelWidth) / (c.scaledPixelWidth - 640.0f)) / 2.0f;
			//c.orthographicSize = (scs.orthoSizeFromTexture * (1.5f)) / scs.multiplierFromTexture;
			c.orthographicSize = (scs.orthoSizeFromTexture * (c.scaledPixelWidth / 1280.0f)) / scs.multiplierFromTexture;
		}

		public void SetCHolder(Camera c, RawImage ri, IsometricOrtho_Container scs, GameObject cH)
		{
			cH.transform.localPosition = scs.CameraPosition;
			cH.transform.localEulerAngles = scs.CameraRotation;
		}

		public override void UpdateIsoScene(Camera c, RawImage ri, IsometricOrtho_Container scs, ScrollRect sr, Camera oc, GameObject cH)
		{
			if (scs.isAnimated == true)
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