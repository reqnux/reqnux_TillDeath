using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer (typeof(AvailableItem))]
public class AvailableItemDrawer : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		EditorGUI.BeginProperty(position, label, property);

		Rect pos = EditorGUI.PrefixLabel(position, label);

		float rowWidth = pos.width;

		Rect startTimeRect = new Rect(pos.x , pos.y, rowWidth*0.75f, pos.height);
		Rect spawnTypeRect = new Rect(pos.x + rowWidth*0.75f + 2, pos.y, rowWidth*0.25f, pos.height);

		EditorGUI.PropertyField(startTimeRect, property.FindPropertyRelative ("item"),GUIContent.none);
		EditorGUI.PropertyField(spawnTypeRect, property.FindPropertyRelative ("available"),GUIContent.none);

		EditorGUI.EndProperty();
	}
}
