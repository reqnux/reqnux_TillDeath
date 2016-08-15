using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(MissionScenario))]
public class ScenarioListInspector : Editor {

	public override void OnInspectorGUI ()
	{
		serializedObject.Update ();
		show (serializedObject.FindProperty ("scenarioEvents"));
		serializedObject.ApplyModifiedProperties ();
	}

	void show(SerializedProperty list) {
		EditorGUILayout.PropertyField (list);
		if (list.isExpanded) {
			EditorGUILayout.PropertyField (list.FindPropertyRelative ("Array.size"));
			EditorGUILayout.Space ();
			for (int i = 0; i < list.arraySize; i++) {
				EditorGUILayout.PropertyField (list.GetArrayElementAtIndex (i), GUIContent.none);
			}
		}

	}
}
