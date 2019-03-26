using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AKNew
{
	[CreateAssetMenu(menuName = "Containers/Isometric Ortho Container")]
	public class IsometricOrtho_Container : ScriptableObject
	{
		public bool isAnimated;

		public float referenceOrthoSizeMaya;
		public float FloatForNearClip;
		public float FloatForFarClip;
		public Texture2D depthTexture;
		public Texture2D renderedTexture;
		public Vector3 CameraPosition;
		public Vector3 CameraRotation;

		public List<Texture2D> depthTextureSequence = new List<Texture2D>();
		public List<Texture2D> renderedTextureSequence = new List<Texture2D>();
		public float floatForCoroutineAnimation;
		public bool isLoopableAnimation;
		public bool containsTransitionScene;

		[Header("On Enable Variables")]
		[Tooltip("Width taken from the depth texture")]
		public float widthFromTexture;
		[Tooltip("Height taken from the depth texture")]
		public float heightFromTexture;
		public float multiplierFromTexture;
		public float secondMultiplierFromTexture;
		[Tooltip("14.04f * (2560 / the texture width) = 'Standard Orthographic Size * RATIO'")]
		public float orthoSizeFromTexture;
		public float orthoRatioForZoom;
		public float aspectRatio;
		public float xAnchoredOffset;
		public float yAnchoredOffset;
		public float xOffset;
		public float yOffset;
		public float rayXOffset;
		public float rayYOffset;
		public float rectSizeMult1;
		public float rectSizeScalar;

		public void OnEnable()
		{
			// All the following are ReferenceOrthoSizeMaya dependent.
			// Ortho for 2560 is 14.04, this is for orthographic size of 100 in maya, following is multiplied by ratio
			float initialOrtho = 14.04f * (referenceOrthoSizeMaya / 100.0f);
			// Offset for 2560 is 2560, this is for orthographic size of 100 in maya, following is multiplied by ratio
			float initialOffset = 2560.0f * (referenceOrthoSizeMaya / 100.0f);
			// Offset for 2560 is 25, this is for orthographic size of 100 in maya, following is multiplied by ratio
			float initialXY = 25.0f * (referenceOrthoSizeMaya / 100.0f);

			// OnEnable() variables for static sequence  // && depthTexture != null && renderedTexture != null
			if (isAnimated == false && depthTexture != null && renderedTexture != null)
			{
				widthFromTexture = depthTexture.width;
				heightFromTexture = depthTexture.height;

				multiplierFromTexture = 5120.0f / widthFromTexture;
				secondMultiplierFromTexture = (5120.0f * 2) / widthFromTexture;

				// All the following are Texture Dependent Variables.
				orthoSizeFromTexture = (initialOrtho * (2560.0f / widthFromTexture));
				// For 5120, mul1 = 1, mul2 = 2. For 2560, mul1 = 2, mul2 = 4 (HOWEVER THIS CAUSES DISTORTION!)
				// Use 5120 for MayaOrtho 50, only use 2560 for testing purposes
				// I should get something like 5.265

				if (widthFromTexture >= heightFromTexture)
				{
					aspectRatio = widthFromTexture / heightFromTexture;
					xAnchoredOffset = initialOffset;
					yAnchoredOffset = initialOffset / aspectRatio;
					xOffset = initialXY;
					yOffset = initialXY / aspectRatio;
					orthoRatioForZoom = (5120.0f / widthFromTexture);
					rayXOffset = 320.0f * (widthFromTexture / 5120.0f);
					rayYOffset = 180.0f * (heightFromTexture / 2880.0f);
					//rectSizeMult1 = ((360.0f) / (270.0f * 720.0f));
					rectSizeScalar = (widthFromTexture / 2560.0f);
				}
				else
				{
					aspectRatio = heightFromTexture / widthFromTexture;
					xAnchoredOffset = initialOffset / aspectRatio;
					yAnchoredOffset = initialOffset;
					xOffset = initialXY / aspectRatio;
					yOffset = initialXY;
					orthoRatioForZoom = (2880.0f / widthFromTexture);
					rayXOffset = 320.0f * (widthFromTexture / 5120.0f);
					rayYOffset = 180.0f * (heightFromTexture / 2880.0f);
				}
			}

			// OnEnable() variables for anim sequence //  && depthTextureSequence[0] != null && renderedTextureSequence[0] != null
			if (isAnimated == true && depthTextureSequence[0] != null && renderedTextureSequence[0] != null)
			{
				widthFromTexture = depthTextureSequence[0].width;
				heightFromTexture = depthTextureSequence[0].height;

				multiplierFromTexture = 5120.0f / widthFromTexture;
				secondMultiplierFromTexture = (5120.0f * 2) / widthFromTexture;

				// All the following are Texture Dependent Variables.
				orthoSizeFromTexture = (initialOrtho * (2560.0f / widthFromTexture));
				// For 5120, mul1 = 1, mul2 = 2. For 2560, mul1 = 2, mul2 = 4 (HOWEVER THIS CAUSES DISTORTION!)
				// Use 5120 for MayaOrtho 50, only use 2560 for testing purposes
				// I should get something like 5.265

				if (widthFromTexture >= heightFromTexture)
				{
					aspectRatio = widthFromTexture / heightFromTexture;
					xAnchoredOffset = initialOffset;
					yAnchoredOffset = initialOffset / aspectRatio;
					xOffset = initialXY;
					yOffset = initialXY / aspectRatio;
					orthoRatioForZoom = (5120.0f / widthFromTexture);
					rayXOffset = 320.0f * (widthFromTexture / 5120.0f);
					rayYOffset = 180.0f * (heightFromTexture / 2880.0f);
				}
				else
				{
					aspectRatio = heightFromTexture / widthFromTexture;
					xAnchoredOffset = initialOffset / aspectRatio;
					yAnchoredOffset = initialOffset;
					xOffset = initialXY / aspectRatio;
					yOffset = initialXY;
					orthoRatioForZoom = (2880.0f / widthFromTexture);
					rayXOffset = 320.0f * (widthFromTexture / 5120.0f);
					rayYOffset = 180.0f * (heightFromTexture / 2880.0f);
				}
			}
		}
	}
}
