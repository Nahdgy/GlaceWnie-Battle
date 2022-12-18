using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainHealth : MonoBehaviour
{
    public int healthPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (VanillaIcyHealth.instance.currentHealth != VanillaIcyHealth.instance.maxHealth)
            {
                VanillaIcyHealth.instance.HealPlayer(healthPoints);
                Destroy(gameObject);
            }
        }
    }
}
