using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SO;

namespace AKNew
{
	public class ClassicActionHook : MonoBehaviour
	{
		public List<ClassicPrerenderActions> classicPrerenderActions = new List<ClassicPrerenderActions>();
		public List<ClassicActions> classicActions = new List<ClassicActions>();

		[Header("Necessary Objects for Hook")]
		public Camera perspectiveCamera;
		public RawImage rawImageProjection;
		public Classic_Container fetchedCS;
		public ClassicContainerVariable privateCSVariable;
		public ScrollRect scrollR;
		public Camera orthographicCamera;
		public GameObject cameraHolder;

		[Header("Bool Variables")]
		public BoolVariable runtimeInit;
		public BoolVariable updateScene;
		//public BoolVariable switchScene;
		public BoolVariable playAnimEvent;
		public BoolVariable followModeOn;

		// Implement an OnEnable Variable for the new Set Container System.
		IEnumerator PlayPrerenderedAnimation_Coroutine(Camera c, RawImage ri, Classic_Container cs, GameObject cH, float time)
		{
			//ri.rectTransform.sizeDelta = new Vector2(c.scaledPixelWidth, c.scaledPixelHeight);

			// This is Logic for a Static Animation : Good for backgrounds
			while (playAnimEvent.value == true && cs.containsTransitionScene == false)
			{
				for (int i = 0; i < cs.DepthTextureBoiSequence.Count; i++)
				{
					ri.material.SetTexture("_RenderedTex", cs.DepthTextureBoiSequence[i]);
					ri.material.SetTexture("_DepthTex", cs.DepthTextureBoiSequence[i]);
					//Debug.Log(i + "Count is <=");
					if (i == cs.RenderedTextureBoiSequence.Count - 1 && cs.isLoopableAnimation == false)
					{
						playAnimEvent.value = false;
						yield return new WaitForSeconds(time);
					}

					yield return new WaitForSeconds(time);
				}
			}

			// This is Logic for a Transition Animation
			while (playAnimEvent.value == true && cs.containsTransitionScene == true)
			{
				// This is Logic for a Transition Animation : Good for dynamic cutscenes
				for (int i = 0; i < cs.RenderedTextureBoiSequence.Count; i++)
				{
					c.fieldOfView = cs.FOVValueForTransitionSequence[i];
					c.nearClipPlane = cs.NearClipForTransitionSequence[i];
					c.farClipPlane = cs.FarClipForTransitionSequence[i];

					ri.material.SetFloat("_Near", cs.NearClipForTransitionSequence[i]);
					ri.material.SetFloat("_Far", cs.FarClipForTransitionSequence[i]);
					ri.material.SetTexture("_RenderedTex", cs.RenderedTextureBoiSequence[i]);
					ri.material.SetTexture("_DepthTex", cs.DepthTextureBoiSequence[i]);
					
					cH.transform.localPosition = cs.cameraPositionsForTransitionSequence[i];
					cH.transform.eulerAngles = cs.cameraRotationsForTransitionSequence[i];
					
					if (i == cs.RenderedTextureBoiSequence.Count - 1 && cs.isLoopableAnimation == false)
					{
						playAnimEvent.value = false;
						yield return new WaitForSeconds(time);
					}

					yield return new WaitForSeconds(time);
				}
			}

			//yield return new WaitForFixedUpdate();
		}

		public void UpdateColliderTransition(Classic_Container cs)
		{
			playAnimEvent.value = false;
			StopAllCoroutines();

			fetchedCS = cs;
			updateScene.value = true;
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
			this.transform.position = new Vector3(0, 0, 0);
			//runtimeInit.value = true;
			//vec2ForLerp.value = new Vector2(0, 0);
			privateCSVariable.value = fetchedCS;
			updateScene.value = true;
		}


		// Update is called once per frame
		void Update()
		{
			rawImageProjection.material.SetMatrix("_Perspective", perspectiveCamera.projectionMatrix);

			/*
			// Temporary solution
			if (switchScene.value == true)
			{
				//SceneManager.LoadScene(sceneStringClassical);
				updateScene.value = true;
				switchScene.value = false;
			}*/

			if (updateScene.value == true)
			{
				fetchedCS = privateCSVariable.value;

				StopAllCoroutines();
				//StopCoroutine(PlayPrerenderedAnimation_Coroutine);
				for (int i = classicPrerenderActions.Count - 1; i >= 0; i--)
				{
					classicPrerenderActions[i].UpdateClassicScene(perspectiveCamera, rawImageProjection, fetchedCS, scrollR, orthographicCamera, cameraHolder);
					if (playAnimEvent.value == true)
					{
						//StopAllCoroutines();
						StartCoroutine(PlayPrerenderedAnimation_Coroutine(perspectiveCamera, rawImageProjection, fetchedCS, cameraHolder, fetchedCS.floatForCoroutineAnimation));
						Debug.Log("Initializing Coroutine for Animated Container");
						updateScene.value = false;
					}
					else
					{
						updateScene.value = false;
					}
				}
			}

			for (int i = classicActions.Count - 1; i >= 0; i--)
			{
				classicActions[i].ExecuteClassic(perspectiveCamera, rawImageProjection, fetchedCS, cameraHolder);
			}
		}
	}
}