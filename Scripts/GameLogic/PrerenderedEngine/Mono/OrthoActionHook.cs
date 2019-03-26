using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SO;

namespace AKNew
{
	public class OrthoActionHook : MonoBehaviour
	{
		// This is set in the scene.
		// Please set all variables.

		public List<OrthoPrerenderActions> orthoPrerenderActions = new List<OrthoPrerenderActions>();
		public List<OrthoActions> orthoCameraActions = new List<OrthoActions>();

		[Header("Necessary Objects for Hook")]
		public Camera overheadCamera;
		public RawImage rawImageProjection;
		public IsometricOrtho_Container fetchedIO_C;
		public ScrollRect scrollR;
		public Camera orthographicCamera;
		public GameObject cameraHolder;

		[Header("Bool Variables")]
		public BoolVariable updateScene;
		public BoolVariable playAnimEvent;
		public BoolVariable followModeOn;
		public BoolVariable transitionCameraEvent;

		[Header("SO Variables")]
		public Vector2Variable vec2ForLerp;
		public FloatVariable deltaFloat;

		// Implement an OnEnable Variable for the new Set Container System.
		IEnumerator PlayPrerenderedAnimation_Coroutine(Camera c, RawImage ri, IsometricOrtho_Container ico, float time)
		{
			// This is Logic for a Loopable Animation : Good for backgrounds
			while (playAnimEvent.value == true)
			{
				for (int i = 0; i < ico.depthTextureSequence.Count; i++)
				{
					ri.material.SetTexture("_RenderedTex", ico.depthTextureSequence[i]);
					ri.material.SetTexture("_DepthTex", ico.depthTextureSequence[i]);
					yield return new WaitForSeconds(time);
				}
			}
		}

		// Keycode as a string, Boolvariable to set, This is used to toggle things on and off.
		public bool UpdateKey(string keyCode, BoolVariable pressed)
		{
			if (Input.GetKeyDown(keyCode))
			{
				if (pressed.value == false)
				{
					print("space key was pressed once, followModeOn is on.");
					return pressed.value = true;
				}
				if (pressed.value == true)
				{
					print("space key was pressed once, followModeOn is off.");
					return pressed.value = false;
				}
			}
			print("Value was returned");
			return pressed.value;
		}

		public void OnEnable()
		{
			updateScene.value = true;
			this.transform.position = new Vector3(0, 0, 0);
		}

		void Update()
		{
			rawImageProjection.material.SetMatrix("_Perspective", overheadCamera.projectionMatrix);

			if (updateScene.value == true)
			{
				for (int i = orthoPrerenderActions.Count - 1; i >= 0; i--)
				{
					orthoPrerenderActions[i].UpdateIsoScene(overheadCamera, rawImageProjection, fetchedIO_C, scrollR, orthographicCamera, cameraHolder);
					if (playAnimEvent.value == true)
					{
						StopAllCoroutines();
						StartCoroutine(PlayPrerenderedAnimation_Coroutine(overheadCamera, rawImageProjection, fetchedIO_C, fetchedIO_C.floatForCoroutineAnimation));
						Debug.Log("Initializing Coroutine for Animated Container");
						updateScene.value = false;
					}
					else
					{
						updateScene.value = false;
					}
				}
			}

			for (int i = orthoCameraActions.Count - 1; i >= 0; i--)
			{
				orthoCameraActions[i].Execute(overheadCamera, rawImageProjection, fetchedIO_C, cameraHolder);
			}
		}

		
		// FixedUpdate works but provides some lag... LateUpdate() has some delay between update and lateupdate actions
		// Find a solution to the eternal problem.
		void FixedUpdate()
		{
			UpdateKey("f", followModeOn);
			//UpdateKey("f", transitionCameraEvent);
			
			if (transitionCameraEvent.value == true && followModeOn.value == true)
			{
				rawImageProjection.rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(rawImageProjection.rectTransform.anchoredPosition.x, vec2ForLerp.value.x, deltaFloat.value), Mathf.Lerp(rawImageProjection.rectTransform.anchoredPosition.y, vec2ForLerp.value.y, deltaFloat.value));         // original delta = Time.deltaTime * 2		
			}
		}
	}
}