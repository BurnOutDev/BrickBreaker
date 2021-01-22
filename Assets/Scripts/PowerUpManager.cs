using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;
    public List<GameObject> dropSet = new List<GameObject>();

    [Range(0, 100)]
    public int dropChance;

    void Awake()
    {
        instance = this;
    }

    public void DropPowerUp(Vector3 pos)
    {
        int rand = Random.Range(0, 101);
        if (rand <= dropChance)
        {
            int index = Random.Range(0, dropSet.Count);
            Instantiate(dropSet[index], pos, Quaternion.Euler(0,0,90));
        }
    }
}
