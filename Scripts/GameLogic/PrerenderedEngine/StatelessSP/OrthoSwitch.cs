using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SA;
using SO;

namespace AKNew
{
	[CreateAssetMenu(menuName = "OrthoActions/Cases/Switch Camera Logic")]
	public class OrthoSwitch : OrthoActions
	{
		public InputAxis horizontalAxis;
		public InputAxis verticalAxis;
		//public InputAxis middleWheelAxis;
		public Vector2 currentAnchoredPosition;

		public float mouseAxis;

		[Header("SO Library Variables")]
		public BoolVariable panBool;
		public BoolVariable zoomBool;
		public BoolVariable followModeOn;
		public BoolVariable cameraTransEvent;
		public Vector2Variable runtimeVector2;
		public Vector3Variable runtimeVector3;
		public FloatVariable orthoScaledSizeFromTexture;
		public FloatVariable amount;

		public void SetOrthoVector3(RawImage ri, Camera c, IsometricOrtho_Container scs)
		{
			float newMulForZoomAndScreenX = ((2 / ri.rectTransform.sizeDelta.x) * (ri.rectTransform.sizeDelta.x - c.scaledPixelWidth));
			float newMulForZoomAndScreenY = ((2 / ri.rectTransform.sizeDelta.y) * (ri.rectTransform.sizeDelta.y - c.scaledPixelHeight));

			c.transform.localPosition = new Vector3(
				Mathf.Clamp(-ri.rectTransform.anchoredPosition.x * 0.0195313f * ((scs.xAnchoredOffset * 2) / ri.rectTransform.sizeDelta.x),
				-scs.xOffset * newMulForZoomAndScreenX, scs.xOffset * newMulForZoomAndScreenX),
				Mathf.Clamp(-ri.rectTransform.anchoredPosition.y * 0.0195313f * ((scs.yAnchoredOffset * 2) / ri.rectTransform.sizeDelta.y),
				-scs.yOffset * newMulForZoomAndScreenY, scs.yOffset * newMulForZoomAndScreenY), 0);

			//runtimeVector3.value = c.transform.localPosition;
		}

		public Vector2 SetOrthoCamToRI(RawImage ri, Camera c, IsometricOrtho_Container scs, Vector3 abc)
		{
			// Okay, need to set in SCS. for 5120 mulx = 320 ...., for 2560 muly = 180,
			float mulx = scs.rayXOffset * abc.x * (0.32f * ((orthoScaledSizeFromTexture.value) / c.orthographicSize));
			float muly = scs.rayYOffset * abc.y * (0.568889f * ((orthoScaledSizeFromTexture.value) / c.orthographicSize));

			return new Vector2(mulx, muly);
		}

		public override void Execute(Camera c, RawImage ri, IsometricOrtho_Container scs, GameObject cH)
		{
			//ri.material.SetMatrix("_Perspective", c.projectionMatrix);
			// Get mouse axis
			mouseAxis = Input.GetAxis("Mouse ScrollWheel");

			orthoScaledSizeFromTexture.value = (scs.orthoSizeFromTexture * (c.scaledPixelWidth / 1280.0f));

			// This should run every frame.
			runtimeVector2.value = new Vector2(
					ri.rectTransform.anchoredPosition.x * (c.orthographicSize / (orthoScaledSizeFromTexture.value)) * (5120.0f / scs.widthFromTexture),
					ri.rectTransform.anchoredPosition.y * (c.orthographicSize / (orthoScaledSizeFromTexture.value)) * (5120.0f / scs.widthFromTexture));

			// For Panning Operation
			if (horizontalAxis.value > 0 || horizontalAxis.value < 0 || verticalAxis.value > 0 || verticalAxis.value < 0)
			{
				panBool.value = true;
			}
			else
			{
				panBool.value = false;
			}

			// For Zooming Operation
			if (mouseAxis > 0 || mouseAxis < 0)
			{
				zoomBool.value = true;
				if (mouseAxis > 0)
				{
					amount.value = 1.1f;
				}
				else if (mouseAxis < 0)
				{
					amount.value = 0.9f;
				}
			}
			else
			{
				zoomBool.value = false;
			}

			// For Ray Operation
		}

	}
}