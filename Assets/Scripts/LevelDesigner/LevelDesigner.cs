using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    [Serializable]
    public class StoneSet
    {
        public GameObject brickPrefab;
        public Color32 color;
    }

    public List<StoneSet> brickSet = new List<StoneSet>();

    [Header("Level")]
    public SCR_Level level;

    [Header("Start Position")]
    public Vector2 startPosition;

    [Header("Margin")]
    public float distanceX = 2;
    public float distanceY = 1;

    [Header("Odd Offset")]
    public bool offsetOddRow;
    public float offset = 1;

    void Start()
    {
        CreateLevel();
    }

    void CreateLevel()
    {
        if (level == null) return;

        for (int yIndex = 0; yIndex < level.rows.Length; yIndex++)
        {
            for (int xIndex = 0; xIndex < level.rows[yIndex].columns.Length; xIndex++)
            {
                float xDistance = (yIndex % 2 == 1 && offsetOddRow) ? xIndex * distanceX + offset : xIndex * distanceX;
                Vector3 pos = new Vector3(startPosition.x + xDistance, startPosition.y + yIndex * -distanceY, 0);

                if (level.rows[yIndex].columns[xIndex] != 0)
                {
                    int number = level.rows[yIndex].columns[xIndex];
                    GameObject newBrick = Instantiate(brickSet[number-1].brickPrefab, pos, Quaternion.identity);
                    //Color
                    newBrick.GetComponent<MeshRenderer>().material.color = brickSet[number - 1].color;
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        if (level != null)
        {
            for (int yIndex = 0; yIndex < level.gridSize.y; yIndex++)
            {
                for (int xIndex = 0; xIndex < level.gridSize.x; xIndex++)
                {
                    float xDistance = (yIndex % 2 == 1 && offsetOddRow) ? xIndex * distanceX + offset : xIndex * distanceX;
                    Vector3 pos = new Vector3(startPosition.x + xDistance, startPosition.y + yIndex * -distanceY, 0);

                    Gizmos.DrawWireCube(pos, new Vector3(2, 1, 1));
                }
            }
        }
    }
}
