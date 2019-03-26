using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AKNew
{
	[CustomEditor(typeof(IsometricOrtho_Container))]
	public class IsometricOrtho_Container_Editor : Editor
	{
		override public void OnInspectorGUI()
		{
			var IsoOrtho_Script = target as IsometricOrtho_Container;

			EditorGUILayout.BeginVertical();
			GUILayout.Label("Rule 1: Orthographic Camera Size cannot be 0.");
			GUILayout.Label("Rule 2: Near Clip / Far Clip cannot be the same value.");
			EditorGUILayout.EndVertical();

			#region ToggleForOptions
			/////////////////
			// Start of Toggle Menu
			EditorGUILayout.BeginHorizontal();

			// Left Button
			Rect l_button = EditorGUILayout.BeginVertical();
			if (GUI.Button(l_button, GUIContent.none))
			{
				IsoOrtho_Script.isAnimated = false;
			}
			GUILayout.Label("Press me for Non-Animated Options");

			EditorGUILayout.EndVertical();

			// Right Button
			Rect r_button = EditorGUILayout.BeginVertical();
			if (GUI.Button(r_button, GUIContent.none))
			{
				IsoOrtho_Script.isAnimated = true;
			}
			GUILayout.Label("Press me for Animated Options");
			EditorGUILayout.EndVertical();

			// End of Toggle Menu
			EditorGUILayout.EndHorizontal();
			/////////////////
			#endregion

			if (IsoOrtho_Script.isAnimated == false)
			{
				serializedObject.Update();
				EditorGUILayout.PropertyField(serializedObject.FindProperty("referenceOrthoSizeMaya"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("FloatForNearClip"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("FloatForFarClip"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("renderedTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("depthTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("CameraPosition"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("CameraRotation"), true);
				GUILayout.Label("Do not be concerned if the read-only values below do not update immediatly.");
				EditorGUILayout.PropertyField(serializedObject.FindProperty("widthFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("heightFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("multiplierFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("secondMultiplierFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("orthoSizeFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("orthoRatioForZoom"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("aspectRatio"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("xAnchoredOffset"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("yAnchoredOffset"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("xOffset"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("yOffset"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("rayXOffset"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("rayYOffset"), true);
				serializedObject.ApplyModifiedProperties();
			}

			if (IsoOrtho_Script.isAnimated == true)
			{
				serializedObject.Update();
				EditorGUILayout.PropertyField(serializedObject.FindProperty("referenceOrthoSizeMaya"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("FloatForNearClip"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("FloatForFarClip"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("renderedTextureSequence"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("depthTextureSequence"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("floatForCoroutineAnimation"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("isLoopableAnimation"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("CameraPosition"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("CameraRotation"), true);
				GUILayout.Label("Do not be concerned if the read-only values below do not update immediatly.");
				EditorGUILayout.PropertyField(serializedObject.FindProperty("widthFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("heightFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("multiplierFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("secondMultiplierFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("orthoSizeFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("orthoRatioForZoom"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("aspectRatio"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("xAnchoredOffset"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("yAnchoredOffset"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("xOffset"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("yOffset"), true);
				serializedObject.ApplyModifiedProperties();
			}
		}
	}
}