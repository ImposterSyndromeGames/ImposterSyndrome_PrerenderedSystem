using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using SO;

namespace AKNew
{
	[CreateAssetMenu(menuName = "OrthoActions/Switch Actions/Ray Operations/Ortho Ray Character Follow")]
	public class OrthoRayCharacterFollow : OrthoRayOperation
	{
		public override void Execute(Camera c, RawImage ri, IsometricOrtho_Container scs, GameObject cH)
		{

			/*
			if (followModeOn.value == true)
			{
				if (cameraTransEvent.value == true)
				{
					SetOrthoVector3(ri, c, scs);
				}
			}*/


			/*
			if (Input.GetMouseButtonDown(0))
			{
				Ray myThirdRay = c.ScreenPointToRay(Input.mousePosition);

				RaycastHit hitInfo;

				if (Physics.Raycast(myThirdRay, out hitInfo, 100, clickOnMyLayerDaddy))
				{
					myAgent.SetDestination(hitInfo.point);
				}
			}*/

			//base.Execute(c, ri, scs, cH);
		}
	}
}