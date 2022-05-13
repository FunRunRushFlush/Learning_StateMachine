using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health, maxHealth = 100f;

    private void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(float damageamount)
    {
        health -= damageamount;

        if(health<= 0)
        {
            Destroy(gameObject);
        }
    }

}
