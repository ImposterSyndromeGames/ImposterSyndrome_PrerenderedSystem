using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AKNew
{
	[CustomEditor(typeof(Classic_Container))]
	public class Classic_Container_Editor : Editor
	{
		override public void OnInspectorGUI()
		{
			var Classic_Script = target as Classic_Container;

			/*
			EditorGUILayout.BeginVertical();
			GUILayout.Label("Rules for calculating Field of View.");
			GUILayout.Label("Rule 1: Angle of View from Maya cannot be 0.");
			GUILayout.Label("Rule 2: Near Clip / Far Clip cannot be the same value.");
			GUILayout.Label("Rule 3: Render Height and Render Width must be the resolution of your camera in game, stick to widescreen resolutions.");
			GUILayout.Label("Please see technical document for a thorough explanation as to why.");
			GUILayout.Label("Most modern games are in widescreen resolutions, eg (1280, 720), (1920, 1080) etc.");
			GUILayout.Label("If your game is prerendered in resolutions of say 1280, 720, a game resolution of 1920, 1080 can be used without issue.");
			GUILayout.Label("However if for some strange reason you want square windows or something bizarre like that.");
			EditorGUILayout.EndVertical();

			Classic_Script.angleOfViewFromMaya = EditorGUILayout.FloatField("Field of View for Unity (In future this will be calculated in OnEnable()).", Classic_Script.angleOfViewFromMaya);
			Classic_Script.FOVValue = EditorGUILayout.FloatField("Field of View for Unity (In future this will be calculated in OnEnable()).", Classic_Script.FOVValue);
			Classic_Script.FloatForNearClip = EditorGUILayout.FloatField("Float for Near Clip.", Classic_Script.FloatForNearClip);
			Classic_Script.FloatForFarClip = EditorGUILayout.FloatField("Float for Far Clip.", Classic_Script.FloatForFarClip);
			*/

			#region ToggleForOptions
			/////////////////
			// Start of Toggle Menu
			EditorGUILayout.BeginHorizontal();

			// Left Button
			Rect l_button = EditorGUILayout.BeginVertical();
			if (GUI.Button(l_button, GUIContent.none))
			{
				Classic_Script.isAnimatedContainer = false;
				Classic_Script.containsTransitionScene = false;
			}
			GUILayout.Label("Press me for Non-Animated Options");

			EditorGUILayout.EndVertical();

			// Centre Button
			Rect c_button = EditorGUILayout.BeginVertical();
			if (GUI.Button(c_button, GUIContent.none))
			{
				Classic_Script.isAnimatedContainer = true;
				Classic_Script.containsTransitionScene = false;
			}
			GUILayout.Label("Press me for Animated Options");
			EditorGUILayout.EndVertical();

			// Right Button
			Rect r_button = EditorGUILayout.BeginVertical();
			if (GUI.Button(r_button, GUIContent.none))
			{
				Classic_Script.isAnimatedContainer = true;
				Classic_Script.containsTransitionScene = true;
			}
			GUILayout.Label("Press me for (Transition) Animated Options");
			EditorGUILayout.EndVertical();

			// End of Toggle Menu
			EditorGUILayout.EndHorizontal();
			/////////////////
			#endregion

			if (Classic_Script.isAnimatedContainer == false && Classic_Script.containsTransitionScene == false)
			{
				EditorGUILayout.BeginVertical();
				GUILayout.Label("Rules for calculating Field of View.");
				GUILayout.Label("Rule 1: Angle of View from Maya cannot be 0.");
				GUILayout.Label("Rule 2: Near Clip / Far Clip cannot be the same value.");
				EditorGUILayout.EndVertical();

				serializedObject.Update();
				EditorGUILayout.LabelField("Non-Animated Static Camera", EditorStyles.boldLabel);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("angleOfViewFromMaya"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("FloatForNearClip"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("FloatForFarClip"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("RenderedTextureBoi"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("DepthTextureBoi"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("CameraPosition"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("CameraRotation"), true);
				GUILayout.Label("Do not be concerned if the read-only values below do not update immediatly.");
				EditorGUILayout.PropertyField(serializedObject.FindProperty("widthFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("heightFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("FOVValue"), true);
				serializedObject.ApplyModifiedProperties();
			}

			if (Classic_Script.isAnimatedContainer == true && Classic_Script.containsTransitionScene == false)
			{
				EditorGUILayout.BeginVertical();
				GUILayout.Label("Rules for calculating Field of View.");
				GUILayout.Label("Rule 1: Angle of View from Maya cannot be 0.");
				GUILayout.Label("Rule 2: Near Clip / Far Clip cannot be the same value.");
				GUILayout.Label("Rule 3: Float for Coroutine must not be empty.");
				EditorGUILayout.EndVertical();

				serializedObject.Update();
				EditorGUILayout.LabelField("Animated Static Camera", EditorStyles.boldLabel);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("angleOfViewFromMaya"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("FloatForNearClip"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("FloatForFarClip"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("RenderedTextureBoiSequence"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("DepthTextureBoiSequence"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("floatForCoroutineAnimation"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("isLoopableAnimation"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("CameraPosition"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("CameraRotation"), true);
				GUILayout.Label("Do not be concerned if the read-only values below do not update immediatly.");
				EditorGUILayout.PropertyField(serializedObject.FindProperty("widthFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("heightFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("FOVValue"), true);
				serializedObject.ApplyModifiedProperties();
			}

			if (Classic_Script.isAnimatedContainer == true && Classic_Script.containsTransitionScene == true)
			{
				EditorGUILayout.BeginVertical();
				GUILayout.Label("Rules for calculating Field of View.");
				GUILayout.Label("Rule 1: Angle of View from Maya cannot be 0.");
				GUILayout.Label("Rule 2: Near Clip / Far Clip cannot be the same value.");
				GUILayout.Label("Rule 3: Float for Coroutine must not be empty.");
				EditorGUILayout.EndVertical();

				serializedObject.Update();
				EditorGUILayout.LabelField("Animated Dynamic Camera", EditorStyles.boldLabel);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("AngleOfViewForTransitionSequence"), true);
				//AngleOf
				EditorGUILayout.PropertyField(serializedObject.FindProperty("NearClipForTransitionSequence"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("FarClipForTransitionSequence"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("RenderedTextureBoiSequence"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("DepthTextureBoiSequence"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("floatForCoroutineAnimation"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("isLoopableAnimation"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("cameraPositionsForTransitionSequence"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("cameraRotationsForTransitionSequence"), true);
				GUILayout.Label("Do not be concerned if the read-only values below do not update immediatly.");
				EditorGUILayout.PropertyField(serializedObject.FindProperty("widthFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("heightFromTexture"), true);
				EditorGUILayout.PropertyField(serializedObject.FindProperty("FOVValueForTransitionSequence"), true);
				serializedObject.ApplyModifiedProperties();
			}
		}
	}
}