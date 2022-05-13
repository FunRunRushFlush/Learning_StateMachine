using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveWeapon : Weapon
{
    private List<IDamageable> detectedDamageable = new List<IDamageable>();
 public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();
    }

    public void AddToDetected(Collider2D collision)
    {
        Debug.Log("Add to Detected");
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log("Added");
            detectedDamageable.Add(damageable);
        }

        //IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        //if (knockbackable != null)
        //{
        //    detectedKnockbackables.Add(knockbackable);
        //}
    }
    public void RemoveFromDetected(Collider2D collision)
    {
        Debug.Log("Remove to Detected");
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log("Removed");
            detectedDamageable.Remove(damageable);
        }

        //IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        //if (knockbackable != null)
        //{
        //    detectedKnockbackables.Remove(knockbackable);
        //}
    }
}
