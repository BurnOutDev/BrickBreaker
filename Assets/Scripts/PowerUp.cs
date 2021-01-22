using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Add effects
            ApplyEffect();

            Destroy(gameObject);
        }    
    }

    public Effect effect;

    void ApplyEffect()
    {
        switch (effect)
        {
            case Effect.Multiball:
                GameManager.instance.Multiball();
                break;
            case Effect.Extent:
                GameManager.instance.Extent();
                break;
            case Effect.Laser:
                break;
            default:
                break;
        }
    }

    public enum Effect
    {
        Multiball,
        Extent,
        Laser
    }
}
