using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    public SCR_Level level;
    public bool offsetOddRow;

    public Vector2 startPosition;

    public float distanceX = 2;
    public float distanceY = 1;
    public float offset = 1;

    void OnDrawGizmos()
    {
        if (level != null)
        {
            for (int yIndex = 0; yIndex < level.gridSize.y; yIndex++)
            {
                for (int xIndex = 0; xIndex < level.gridSize.x; xIndex++)
                {
                    float xDistance = (yIndex % 2 == 1 && offsetOddRow) ? xIndex * distanceX + offset : xIndex * distanceX;
                    Vector3 pos = new Vector3(startPosition.x + xDistance, startPosition.y + yIndex * -distanceY);

                    Gizmos.DrawWireCube(pos, new Vector3(2, 1, 1));
                }
            }
        }
    }
}
