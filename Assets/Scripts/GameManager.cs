using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject ballPrefab;
    List<GameObject> balls = new List<GameObject>();
    List<GameObject> bricks = new List<GameObject>();

    public int lives;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CreateBall();
        ResetGame();
    }

    void ResetGame()
    {
        lives = 3;
    }

    #region Ball

    public void CreateBall()
    {
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = Paddle.instance.gameObject.transform.position + new Vector3(0, 1f + 0.5f, 0);
        newBall.transform.SetParent(Paddle.instance.gameObject.transform);
        newBall.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        balls.Add(newBall);
    }

    public void StartBall()
    {
        balls[0].GetComponent<Ball>().StartBall();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && balls.Count > 0)
        {
            if (balls[0] != null && !balls[0].GetComponent<Ball>().BallStarted())
            {
                StartBall();
            }
        }
    }

    #endregion

    #region Bricks 

    public void AddBrick(GameObject brick)
    {
        bricks.Add(brick);
    }

    public void RemoveBrick(GameObject brick)
    {
        bricks.Remove(brick);

        if (bricks.Count == 0)
        {
            Debug.Log("You Won!");
        }
    }

    #endregion

    #region Lives

    void RemoveLife()
    {
        lives--;

        if (lives == 0)
            Debug.Log("You Lost!");
        else
            CreateBall();
    }

    public void LostBall(GameObject ball)
    {
        balls.Remove(ball);
        Destroy(ball);

        if (balls.Count == 0)
        {
            RemoveLife();
        }
    }

    #endregion
}
