using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using SO;

namespace AKNew
{
	[CreateAssetMenu(menuName = "OrthoActions/Switch Actions/Ray Operation")]
	public class OrthoRayOperation : OrthoSwitch
	{
		//private NavMeshAgent myAgent;

		public LayerMask raycastLayer;
		public GameObject charTest;

		public Vector3Variable setVec3;
		public Vector2Variable setVec2;

		public override void Execute(Camera c, RawImage ri, IsometricOrtho_Container scs, GameObject cH)
		{
			// WHAT AM I TRYING TO DO?
			// 1. Converting local position to with accuracy
			// 2. Move capsule to 

			/*if (myAgent != null)
			{
				
			}*/

			if (Input.GetMouseButtonDown(0))
			{
				//Ray myRayScreen = c.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
				Ray myRay = c.ScreenPointToRay(Input.mousePosition);

				RaycastHit hitInfoViewOffset;

				if (Physics.Raycast(myRay, out hitInfoViewOffset, 100, raycastLayer))
				{
					#region InternalInformation
					// cH.transform.InverseTransformDirection is what I want!
					// Bounds are -25.0 to 25.0 for x.
					// Bounds are x to y, but... they do sum up to -14.0265 to 14.0265 for y.
					#endregion

					//cameraTransEvent.value = false;

					Vector3 destination = cH.transform.InverseTransformDirection(hitInfoViewOffset.point);

					setVec2.value = SetOrthoCamToRI(ri, c, scs, new Vector3(-destination.x, -destination.y, 0));
					setVec3.value = hitInfoViewOffset.point;

					SetOrthoVector3(ri, c, scs);

					cameraTransEvent.value = true;
					/*
					if (followModeOn.value == true)
					{
						cameraTransEvent.value = true;
					}
					else
					{
						cameraTransEvent.value = false;
					}*/

					#region testingStuff
					// The offset for x or y is based on the centre of the camera in maya from 0.
					// The really easy way to solve this problem is to just render with the centre on world 0.
					// For SCS_09 destination.y is 'destination.y - 8.303098f'

					//Debug.Log("hitInfo.point X: " + destination.x + ", hitInfo.point Y: " + destination.y);


					//ri.rectTransform.anchoredPosition = new Vector2(setVec2.value.x, setVec2.value.y);
					//ri.rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(ri.rectTransform.anchoredPosition.x, setVec2.value.x, Time.deltaTime), Mathf.Lerp(ri.rectTransform.anchoredPosition.y, setVec2.value.y, Time.deltaTime));


					//Debug.Log(SetOrthoCamToRI(ri, c, scs, new Vector3(charTest.transform.position.x, charTest.transform.position.y, 0)));
					#endregion
				}
			}

			if (cameraTransEvent.value == true)
			{
				SetOrthoVector3(ri, c, scs);
			}

			if (Input.GetMouseButtonDown(1))
			{
				Debug.Log("Currently mouse button 2 does nothing");
			}
			
			//base.Execute(c, ri, scs);
		}
	}
}