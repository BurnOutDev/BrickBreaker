using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public static float initialForce = 600f;
    bool ballStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(0, initialForce, 0));
    }

    void OnCollisionEnter(Collision collision)
    {
        Brick brick = collision.gameObject.GetComponent<Brick>();

        if (brick != null)
        {
            brick.TakeDamage();
        }
    }

    public bool BallStarted() => ballStarted;

    public void StartBall()
    {
        if (!ballStarted)
        {
            rb.isKinematic = false;
            rb.AddForce(new Vector3(initialForce, initialForce, 0));
            ballStarted = true;

            transform.SetParent(transform.parent.parent);
        }
    }
}
