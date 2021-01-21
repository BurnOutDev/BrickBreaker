using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int health = 1;
    public int score = 50;
    
    void Start()
    {
        GameManager.instance.AddBrick(this.gameObject);
    }

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            GameManager.instance.RemoveBrick(gameObject);
            Destroy(gameObject);
        }
    }
}
