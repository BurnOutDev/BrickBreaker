using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public static float initialForce = 600f;

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
}
