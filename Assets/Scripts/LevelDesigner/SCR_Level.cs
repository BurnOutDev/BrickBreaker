using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Bricks/Create Level")]
public class SCR_Level : ScriptableObject
{
    public Vector2Int gridSize;

    public LevelSetup[] rows;
}

[Serializable]
public class LevelSetup
{
    public int[] columns;
}