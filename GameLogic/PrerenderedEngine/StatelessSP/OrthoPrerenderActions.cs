using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AKNew
{
	public abstract class OrthoPrerenderActions : ScriptableObject
	{
		public abstract void UpdateIsoScene(Camera c, RawImage ri, IsometricOrtho_Container io_c, ScrollRect sr, Camera oc, GameObject cH);
	}
}