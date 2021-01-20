using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public static Paddle instance;
    float speed = 10f;

    Rigidbody rb;
    BoxCollider col;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if ((int)h == 0 && rb.velocity == Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }
        rb.MovePosition(transform.position + new Vector3(h, 0, 0).normalized * speed * Time.fixedDeltaTime);
    }
}
