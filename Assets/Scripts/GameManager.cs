using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject ballPrefab;
    List<GameObject> balls = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CreateBall();
    }

    #region Create Ball

    public void CreateBall()
    {
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = Paddle.instance.gameObject.transform.position + new Vector3(0, 1f + 0.5f, 0);
        newBall.transform.SetParent(Paddle.instance.gameObject.transform);
        newBall.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        balls.Add(newBall);
    }

    #endregion
}
