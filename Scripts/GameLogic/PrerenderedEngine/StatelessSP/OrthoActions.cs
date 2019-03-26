using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AKNew
{
	public abstract class OrthoActions : ScriptableObject
	{
		public abstract void Execute(Camera c, RawImage ri, IsometricOrtho_Container io_c, GameObject cH);
	}
}