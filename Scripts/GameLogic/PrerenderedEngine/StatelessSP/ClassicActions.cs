using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AKNew
{
	public abstract class ClassicActions : ScriptableObject
	{
		public abstract void ExecuteClassic(Camera c, RawImage ri, Classic_Container cs, GameObject cH);
	}
}