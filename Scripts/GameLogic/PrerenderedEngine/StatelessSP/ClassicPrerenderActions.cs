using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SO;

namespace AKNew
{
	public abstract class ClassicPrerenderActions : ScriptableObject
	{
		public abstract void UpdateClassicScene(Camera c, RawImage ri, Classic_Container cs, ScrollRect sr, Camera oc, GameObject cH);
	}
}