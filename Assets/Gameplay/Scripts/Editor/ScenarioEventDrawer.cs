using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(MissionScenarioEvent))]
public class ScenarioEventDrawer : PropertyDrawer {

	int rows = 4;

	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty(position, label, property);

		// Draw label
		Rect pos = EditorGUI.PrefixLabel(position, label);
		// Don't make child fields be indented
		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		float rowHeight = 16;// = contentPosition.height / rows;
		float rowWidth = pos.width;
		float enumWidth = 150;
		float floatWidth = 80;
		// Calculate rects
		Rect startTimeRect = new Rect(pos.x , pos.y, rowWidth, rowHeight);
		Rect spawnTypeRect = new Rect(pos.x, pos.y + rowHeight +2, enumWidth, rowHeight);
		Rect durationRect = new Rect(pos.x+enumWidth + 2, pos.y + rowHeight+2, floatWidth, rowHeight);
		Rect enemyTypeRect = new Rect(pos.x, pos.y + 2*rowHeight+4, enumWidth, rowHeight);
		Rect enemyCountRect = new Rect(pos.x+enumWidth+2, pos.y + 2*rowHeight+4, floatWidth, rowHeight);
		Rect spawnSideRect = new Rect(pos.x, pos.y + 3*rowHeight+6, floatWidth, rowHeight);

		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		EditorGUI.PropertyField(startTimeRect, property.FindPropertyRelative ("startTime"));
		EditorGUI.indentLevel = 1;
		EditorGUI.PropertyField(spawnTypeRect, property.FindPropertyRelative ("spawnType"),GUIContent.none);
		if ((MissionScenarioEvent.SpawnType)property.FindPropertyRelative ("spawnType").enumValueIndex
		   == MissionScenarioEvent.SpawnType.OVER_TIME)
			EditorGUI.PropertyField(durationRect, property.FindPropertyRelative ("duration"),GUIContent.none);
		EditorGUI.PropertyField(enemyTypeRect, property.FindPropertyRelative ("enemyType"),GUIContent.none);
		EditorGUI.PropertyField(enemyCountRect, property.FindPropertyRelative ("enemyCount"),GUIContent.none);
		EditorGUI.PropertyField(spawnSideRect, property.FindPropertyRelative ("spawnSide"),GUIContent.none);

		// Set indent back to what it was
		EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
		return base.GetPropertyHeight (property, label) * rows + 8;
	}
}