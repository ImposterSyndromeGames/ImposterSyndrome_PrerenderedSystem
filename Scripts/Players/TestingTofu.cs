using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SO;

namespace AKNew
{
	//[CreateAssetMenu(menuName = "AKNew Testing Prefabs/Testing Tofu")]
	public class TestingTofu : MonoBehaviour
	{
		private NavMeshAgent myAgent;

		public Vector3Variable destinationVec3;

		void Start ()
		{
			myAgent = GetComponent<NavMeshAgent>();
		}

		void Update()
		{
			if (Input.GetMouseButtonDown (0))
			{
				myAgent.SetDestination(destinationVec3.value);

				#region RedundantOldFashionedWay
				/*
				Ray myRay = cameraForRay.ScreenPointToRay(Input.mousePosition);
				
				RaycastHit hitInfo;

				if (Physics.Raycast(myRay, out hitInfo, 100, clickOnMyLayerDaddy))
				{
					myAgent.SetDestination(hitInfo.point);
				}
				//Debug.Log("hitInfo : " + hitInfo.point);
				*/
				#endregion
			}
		}
	}
}