using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SO;

namespace AKNew
{
	[CreateAssetMenu(menuName = "OrthoPrerenderActions/Switch Actions/Ortho Prerender Set")]
	public class OrthoPrerenderSet : OrthoPrerenderSwitch
	{
		public override void UpdateIsoScene(Camera c, RawImage ri, IsometricOrtho_Container scs, ScrollRect sr, Camera oc, GameObject cH)
		{
			SetRI(c, ri, scs, sr);
			SetC(c, ri, scs);
			SetCHolder(c, ri, scs, cH);

			#region trash
			//thePosition = cH.transform.TransformPoint(Vector3.right);
			//Instantiate(c, thePosition, cH.transform.rotation);
			//Debug.Log("The Position is: " + thePosition);
			//Vector3 localDirection = c.transform.InverseTransformDirection(

			//base.UpdateScene(c, ri, scs, sr, oc);
			#endregion
		}
	}
}