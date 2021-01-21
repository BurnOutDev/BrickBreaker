using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SCR_Level))]
public class SCR_LevelEditor : Editor
{
    // Grid
    int cellWidth = 32;
    int cellHeight = 16;
    int margin = 5;
    Rect rect;

    SerializedObject level;
    SerializedProperty gridSize;
    SerializedProperty rows;

    Vector2Int newGridSize;
    Vector2Int cellSize;

    bool wrongSize;
    bool gridChanged;

    void OnEnable()
    {
        level = new SerializedObject(target);
        gridSize = level.FindProperty(nameof(SCR_Level.gridSize));
        rows = level.FindProperty(nameof(SCR_Level.rows));

        newGridSize = gridSize.vector2IntValue;
        cellSize = new Vector2Int(cellWidth, cellHeight);
    }

    public override void OnInspectorGUI()
    {
        level.Update();

        EditorGUILayout.BeginHorizontal();
        {
            EditorGUI.BeginChangeCheck();
            newGridSize = EditorGUILayout.Vector2IntField("Grid Size", newGridSize);

            wrongSize = newGridSize.x <= 0 || newGridSize.y <= 0;
            gridChanged = newGridSize != gridSize.vector2IntValue;

            GUI.enabled = gridChanged && !wrongSize;
            if (GUILayout.Button("Apply", EditorStyles.miniButton))
            {
                //Create new cell grid
            }
            GUI.enabled = true;
        }
        EditorGUILayout.EndHorizontal();

        if (wrongSize)
        {
            EditorGUILayout.HelpBox("Values have to be higher than 0", MessageType.Error);
        }
        EditorGUILayout.Space();

        //Get correct spacing
        if (Event.current.type == EventType.Repaint)
        {
            rect = GUILayoutUtility.GetLastRect();
        }

        //Display grid

        level.ApplyModifiedProperties();
    }
}
