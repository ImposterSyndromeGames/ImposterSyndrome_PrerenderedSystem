using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AKNew
{
	[CreateAssetMenu(menuName = "ClassicPrerenderActions/Cases/Classic Prerender Set")]
	public class ClassicPrerenderSet : ClassicPrerenderSwitch
	{
		public override void UpdateClassicScene(Camera c, RawImage ri, Classic_Container cs, ScrollRect sr, Camera oc, GameObject cH)
		{
			SetRI(c, ri, cs, sr);
			SetC(c, ri, cs);
			SetCHolder(ri, cs, cH);
		}
	}
}