using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTestDummy : MonoBehaviour, IDamageable, IKnockbackable
{
    private Animator anim;
    public Player player;
    public GameObject hitParticles;
    public Rigidbody2D rb;

    public float maxHealth = 1000f;
    public float currentHealth;

    public float maxKnockbackTime = 0.2f;

    //private bool isKnockbackActive;
    private float knockbackStartTime;
    private Vector2 workspace;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;
    }
    public void Knockback(Vector2 angle, float strength, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * strength * direction, angle.y * strength);
        rb.velocity = workspace;
        //isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    public void Damage(float amount)
    {
        currentHealth -= amount;

        //Instantiate(hitParticles, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        Debug.Log(amount + " Damage done");
        
        if (currentHealth <= 0)
        {
            
            Destroy(gameObject);
            Debug.Log("Health is Zero --> Dead");
        }
    }
}
