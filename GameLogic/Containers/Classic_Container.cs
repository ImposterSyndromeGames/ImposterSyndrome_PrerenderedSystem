using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AKNew
{
	[CreateAssetMenu(fileName = "Classic View Container", menuName = "Containers/Classic View Container")]
	public class Classic_Container : ScriptableObject
	{
		public bool isAnimatedContainer;
		
		public float angleOfViewFromMaya;
		public float FloatForNearClip;
		public float FloatForFarClip;
		public Texture2D RenderedTextureBoi;
		public Texture2D DepthTextureBoi;
		public Vector3 CameraPosition;
		public Vector3 CameraRotation;

		
		public List<float> AngleOfViewForTransitionSequence = new List<float>();
		public List<float> NearClipForTransitionSequence = new List<float>();
		public List<float> FarClipForTransitionSequence = new List<float>();
		public List<Texture2D> RenderedTextureBoiSequence = new List<Texture2D>();
		public List<Texture2D> DepthTextureBoiSequence = new List<Texture2D>();
		//public AnimationClip renderedSequence;
		//public AnimationClip depthSequence;
		public float floatForCoroutineAnimation;
		public bool isLoopableAnimation;

		
		public bool containsTransitionScene;
		public List<Vector3> cameraPositionsForTransitionSequence = new List<Vector3>();
		public List<Vector3> cameraRotationsForTransitionSequence = new List<Vector3>();

		[Header("Universal - Scroll View Variables")]
		public float scrollViewWidth;
		public float scrollViewHeight;

		[Header("On Enable Variables")]
		[Tooltip("Width taken from the rendered texture")]
		public float widthFromTexture;
		[Tooltip("Height taken from the rendered texture")]
		public float heightFromTexture;
		public float FOVValue;
		public List<float> FOVValueForTransitionSequence = new List<float>();
		public float multiplierFromTexture;
		public float secondMultiplierFromTexture;
		[Tooltip("14.04f * (2560 / the texture width) - 'Standard Orthographic Size * RATIO'")]
		public float orthoSizeFromTexture;
		public float orthoScaledSizeFromTexture; // Fix me for the refactor later.
		public float orthoRatioForZoom;
		public float aspectRatio;
		public float xAnchoredOffset;
		public float yAnchoredOffset;
		public float xOffset;
		public float yOffset;
		public float rayXOffset;
		public float rayYOffset;

		public void OnEnable()
		{
			if (isAnimatedContainer == false && containsTransitionScene == false && DepthTextureBoi != null && RenderedTextureBoi != null)
			{
				// All of this for calculating the Field of View, by converting the horizontal fov from Maya to vertical fov in Unity.
				widthFromTexture = DepthTextureBoi.width;
				heightFromTexture = DepthTextureBoi.height;

				float a1 = (angleOfViewFromMaya * Mathf.PI) / 180.0f;
				float a2 = a1 / 2.0f;
				float a3 = 2.0f * Mathf.Atan(Mathf.Tan(a2) * (heightFromTexture / widthFromTexture));
				FOVValue = (180.0f * a3) / Mathf.PI;
				//Debug.Log("VerticalFOV: " + FOVValue + ", we are expecting around 32.2673");
			}

			if (isAnimatedContainer == true && containsTransitionScene == false && DepthTextureBoiSequence[0] != null && RenderedTextureBoiSequence[0] != null)
			{
				// All of this for calculating the Field of View, by converting the horizontal fov from Maya to vertical fov in Unity.
				if (DepthTextureBoiSequence[0] != null)
				{
					widthFromTexture = DepthTextureBoiSequence[0].width;
					heightFromTexture = DepthTextureBoiSequence[0].height;

					float a1 = (angleOfViewFromMaya * Mathf.PI) / 180.0f;
					float a2 = a1 / 2.0f;
					float a3 = 2.0f * Mathf.Atan(Mathf.Tan(a2) * (heightFromTexture / widthFromTexture));
					FOVValue = (180.0f * a3) / Mathf.PI;
				}
				//Debug.Log("VerticalFOV: " + FOVValue + ", we are expecting around 32.2673");
			}

			if (isAnimatedContainer == true && containsTransitionScene == true && DepthTextureBoiSequence[0] != null && RenderedTextureBoiSequence[0] != null)
			{
				// All of this for calculating the Field of View, by converting the horizontal fov from Maya to vertical fov in Unity.
				if (DepthTextureBoiSequence[0] != null)
				{
					for (int i = 0; i < DepthTextureBoiSequence.Count; i++)
					{
						widthFromTexture = DepthTextureBoiSequence[i].width;
						heightFromTexture = DepthTextureBoiSequence[i].height;
						float a1 = (AngleOfViewForTransitionSequence[i] * Mathf.PI) / 180.0f;
						float a2 = a1 / 2.0f;
						float a3 = 2.0f * Mathf.Atan(Mathf.Tan(a2) * (heightFromTexture / widthFromTexture));
						FOVValueForTransitionSequence[i] = (180.0f * a3) / Mathf.PI;
					}
				}
				//Debug.Log("VerticalFOV: " + FOVValue + ", we are expecting around 32.2673");
			}
		}
	}
}