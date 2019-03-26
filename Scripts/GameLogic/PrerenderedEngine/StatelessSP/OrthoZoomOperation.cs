using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SO;

namespace AKNew
{
	[CreateAssetMenu(menuName = "OrthoActions/Switch Actions/Zoom Operation")]
	public class OrthoZoomOperation : OrthoSwitch
	{
		[Header("Ortho Zoom Variables")]
		public string targetString;

		public override void Execute(Camera c, RawImage ri, IsometricOrtho_Container scs, GameObject cH)
		{
			//base.Execute(c, ri, scs);
			if (zoomBool.value == true)
			{
				cameraTransEvent.value = false;
				Debug.Log("Zoom Operation Is On!");

				c.orthographicSize /= amount.value;
				ri.rectTransform.sizeDelta *= new Vector2(amount.value, amount.value);

				// Limit Zoom (Ortho Size)
				if (c.orthographicSize >= orthoScaledSizeFromTexture.value / scs.multiplierFromTexture)
				{
					c.orthographicSize = orthoScaledSizeFromTexture.value / scs.multiplierFromTexture;
				}
				if (c.orthographicSize <= orthoScaledSizeFromTexture.value / scs.secondMultiplierFromTexture)
				{
					c.orthographicSize = orthoScaledSizeFromTexture.value / scs.secondMultiplierFromTexture;
				}

				// Limit Zoom (Raw Image Size Delta)
				if (ri.rectTransform.sizeDelta.x <= scs.widthFromTexture * scs.multiplierFromTexture)
				{
					ri.rectTransform.sizeDelta = new Vector2(scs.widthFromTexture * scs.multiplierFromTexture, scs.heightFromTexture * scs.multiplierFromTexture);
				}
				if (ri.rectTransform.sizeDelta.x >= scs.widthFromTexture * scs.secondMultiplierFromTexture)
				{
					ri.rectTransform.sizeDelta = new Vector2(scs.widthFromTexture * scs.secondMultiplierFromTexture, scs.heightFromTexture * scs.secondMultiplierFromTexture);
				}
				
				if (c.transform.localPosition.x > 0)
				{
					if (c.transform.localPosition.y > 0)
					{
						targetString = "x > 0, y > 0";
						ri.rectTransform.anchoredPosition = new Vector2(
						Mathf.Clamp(ri.rectTransform.anchoredPosition.x * amount.value, runtimeVector2.value.x * 2, runtimeVector2.value.x),
						Mathf.Clamp(ri.rectTransform.anchoredPosition.y * amount.value, runtimeVector2.value.y * 2, runtimeVector2.value.y));
						SetOrthoVector3(ri, c, scs);
					}
					else if (c.transform.localPosition.y < 0)
					{
						targetString = "x > 0, y < 0";
						ri.rectTransform.anchoredPosition = new Vector2(
						Mathf.Clamp(ri.rectTransform.anchoredPosition.x * amount.value, runtimeVector2.value.x * 2, runtimeVector2.value.x),
						Mathf.Clamp(ri.rectTransform.anchoredPosition.y * amount.value, runtimeVector2.value.y, runtimeVector2.value.y * 2));
						SetOrthoVector3(ri, c, scs);
					}
				}

				// if x < 0
				if (c.transform.localPosition.x < 0)
				{
					if (c.transform.localPosition.y > 0)
					{
						targetString = "x < 0, y > 0";
						ri.rectTransform.anchoredPosition = new Vector2(
						Mathf.Clamp(ri.rectTransform.anchoredPosition.x * amount.value, runtimeVector2.value.x, runtimeVector2.value.x * 2),
						Mathf.Clamp(ri.rectTransform.anchoredPosition.y * amount.value, runtimeVector2.value.y * 2, runtimeVector2.value.y));
						SetOrthoVector3(ri, c, scs);
					}
					else if (c.transform.localPosition.y < 0)
					{
						targetString = "x < 0, y < 0";
						ri.rectTransform.anchoredPosition = new Vector2(
						Mathf.Clamp(ri.rectTransform.anchoredPosition.x * amount.value, runtimeVector2.value.x, runtimeVector2.value.x * 2),
						Mathf.Clamp(ri.rectTransform.anchoredPosition.y * amount.value, runtimeVector2.value.y, runtimeVector2.value.y * 2));
						SetOrthoVector3(ri, c, scs);
					}
				}

				// If x = 0
				if (c.transform.localPosition.x == 0)
				{
					if (c.transform.localPosition.y > 0)
					{
						targetString = "x = 0, y > 0";
						ri.rectTransform.anchoredPosition = new Vector2(
						0,
						Mathf.Clamp(ri.rectTransform.anchoredPosition.y * amount.value, runtimeVector2.value.y * 2, runtimeVector2.value.y));
						SetOrthoVector3(ri, c, scs);
					}
					else if (c.transform.localPosition.y < 0)
					{
						targetString = "x = 0, y < 0";
						ri.rectTransform.anchoredPosition = new Vector2(
						0,
						Mathf.Clamp(ri.rectTransform.anchoredPosition.y * amount.value, runtimeVector2.value.y, runtimeVector2.value.y * 2));
						SetOrthoVector3(ri, c, scs);
					}
				}

				// If y = 0
				if (c.transform.localPosition.y == 0)
				{
					if (c.transform.localPosition.x > 0)
					{
						targetString = "x > 0, y = 0";
						ri.rectTransform.anchoredPosition = new Vector2(
						Mathf.Clamp(ri.rectTransform.anchoredPosition.x * amount.value, runtimeVector2.value.x * 2, runtimeVector2.value.x),
						0);
						SetOrthoVector3(ri, c, scs);
					}
					else if (c.transform.localPosition.x < 0)
					{
						targetString = "x < 0, y = 0";
						ri.rectTransform.anchoredPosition = new Vector2(
						Mathf.Clamp(ri.rectTransform.anchoredPosition.x * amount.value, runtimeVector2.value.x, runtimeVector2.value.x * 2),
						0);
						SetOrthoVector3(ri, c, scs);
					}
				}

			}
			else
			{
				//cameraTransEvent.value = true;
				Debug.Log("Zoom Operation Is Off!");
			}
		}
	}
}