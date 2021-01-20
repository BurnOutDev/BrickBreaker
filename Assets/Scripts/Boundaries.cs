using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public GameObject leftWall, rightWall, topWall, bottomWall;

    public GameObject lCorner, rCorner;

    float distanceToCamera;
    Vector3 screenBoundaries;
    Vector3 screenPoint;

    void Start()
    {
        distanceToCamera = Camera.main.transform.position.z;
        CalculateBoundaries();
    }

    void CalculateBoundaries()
    {
        float frustrumHeight = 2 * distanceToCamera * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float frustrumWidth = frustrumHeight * Camera.main.aspect;

        screenBoundaries = new Vector3(frustrumWidth, frustrumHeight, 0);
        screenPoint = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);

        #region Left Wall

        Vector3 leftPoint = new Vector3(screenPoint.x - Mathf.Abs(frustrumWidth) / 2, screenPoint.y, 0);
        leftWall.transform.position = leftPoint;
        leftWall.transform.localScale = new Vector3(1, Mathf.Abs(screenBoundaries.y), 1);

        #endregion

        #region Right Wall

        Vector3 rightPoint = new Vector3(screenPoint.x + Mathf.Abs(frustrumWidth) / 2, screenPoint.y, 0);
        rightWall.transform.position = rightPoint;
        rightWall.transform.localScale = new Vector3(1, Mathf.Abs(screenBoundaries.y), 1);

        #endregion

        #region Top Wall

        Vector3 topPoint = new Vector3(screenPoint.x, screenPoint.y + Mathf.Abs(frustrumHeight) / 2, 0);
        topWall.transform.position = topPoint;
        topWall.transform.localScale = new Vector3(Mathf.Abs(screenBoundaries.x), 1, 1);

        #endregion

        #region Bottom Wall

        Vector3 bottomPoint = new Vector3(screenPoint.x, screenPoint.y - Mathf.Abs(frustrumHeight) / 2, 0);
        bottomWall.transform.position = bottomPoint;
        bottomWall.transform.localScale = new Vector3(Mathf.Abs(screenBoundaries.x), 1, 1);

        #endregion

        #region Right Corner

        rCorner.transform.position = new Vector3(rightPoint.x, topPoint.y, 0);
        lCorner.transform.position = new Vector3(leftPoint.x, topPoint.y, 0);

        #endregion
    }
}
