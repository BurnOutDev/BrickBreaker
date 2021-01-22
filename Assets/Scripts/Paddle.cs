using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public static Paddle instance;

    public GameObject center, leftCap, rightCap;

    float speed = 10f;
    public float newSize = 2f;

    Rigidbody rb;
    BoxCollider col;

    bool isScaling = false;
    bool isShrinkingToNormal = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();

        ResetPaddle();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if ((int)h == 0 && rb.velocity != Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }
        rb.MovePosition(transform.position + new Vector3(h, 0, 0).normalized * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            float vel = Ball.initialForce;
            Vector3 hitPoint = collision.contacts[0].point;
            float difference = transform.position.x - hitPoint.x;

            if (hitPoint.x < transform.position.x)
            {
                ballRb.AddForce(new Vector3(-(Mathf.Abs(difference * 200)), vel, 0));
            }
            else
            {
                ballRb.AddForce(new Vector3(Mathf.Abs(difference * 200), vel, 0));
            }
        }
    }

    void Resize(float xScale)
    {
        Vector3 initScale = center.transform.localScale;
        initScale.x = xScale;
        center.transform.localScale = initScale;

        // Left Cap
        Vector3 leftCapPosition = new Vector3(center.transform.position.x - (xScale / 2), leftCap.transform.position.y, leftCap.transform.position.z);
        leftCap.transform.position = leftCapPosition;

        // Right Cap
        Vector3 rightCapPosition = new Vector3(center.transform.position.x + (xScale / 2), rightCap.transform.position.y, rightCap.transform.position.z);
        rightCap.transform.position = rightCapPosition;

        // Collider Scale
        Vector3 colScale = initScale;
        colScale.x += 0.6f * 2;
        col.size = colScale;
    }

    public void ResetPaddle()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, transform.position.z);
        Resize(newSize);
    }

    IEnumerator ResizePaddle(float goalSize, bool isShrinking)
    {
        if (isScaling)
        {
            yield break;
        }

        isScaling = true;

        if (!isShrinking)
        {

        }
        if (goalSize > col.size.x) //Increasing size
        {
            float currentSize = col.size.x - 1;

            while(currentSize < goalSize)
            {
                currentSize += Time.deltaTime * 2;
                Resize(currentSize);
                yield return null;
            }
        }
        else //Decreasing size
        {
            float currentSize = col.size.x - 1;

            while (currentSize > goalSize)
            {
                currentSize += Time.deltaTime * 2;
                Resize(currentSize);
                yield return null;
            }
        }
        Resize(goalSize);

        isScaling = false;
    }
}
