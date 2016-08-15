using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(MissionScenarioEvent))]
public class ScenarioEventDrawer : PropertyDrawer {

	int rows = 3;

	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty(position, label, property);

		// Draw label
		Rect contentPosition = EditorGUI.PrefixLabel(position, label);
		// Don't make child fields be indented
		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		float rowHeight = 16;// = contentPosition.height / rows;
		float rowWidth = contentPosition.width;

		// Calculate rects
		Rect startTimeRect = new Rect(contentPosition.x , contentPosition.y, rowWidth, rowHeight);
		Rect spawnTypeRect = new Rect(contentPosition.x, contentPosition.y + rowHeight +2, rowWidth*0.45f, rowHeight);
		Rect durationRect = new Rect(contentPosition.x+rowWidth/2, contentPosition.y + rowHeight+2, rowWidth/2, rowHeight);
		Rect enemyTypeRect = new Rect(contentPosition.x, contentPosition.y + 2*rowHeight+4, rowWidth/2, rowHeight);
		Rect enemyCountRect = new Rect(contentPosition.x+rowWidth/2, contentPosition.y + 2*rowHeight+4, rowWidth/2, rowHeight);

		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		EditorGUI.PropertyField(startTimeRect, property.FindPropertyRelative ("startTime"));
		EditorGUI.PropertyField(spawnTypeRect, property.FindPropertyRelative ("spawnType"),GUIContent.none);

		if((MissionScenarioEvent.SpawnType)property.FindPropertyRelative ("spawnType").enumValueIndex 
			== MissionScenarioEvent.SpawnType.OVER_TIME)
			EditorGUI.PropertyField(durationRect, property.FindPropertyRelative ("duration"),GUIContent.none);
		EditorGUI.PropertyField(enemyTypeRect, property.FindPropertyRelative ("enemyType"),GUIContent.none);
		EditorGUI.PropertyField(enemyCountRect, property.FindPropertyRelative ("enemyCount"),GUIContent.none);

		// Set indent back to what it was
		EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
		return base.GetPropertyHeight (property, label) * rows + 8;
	}
}