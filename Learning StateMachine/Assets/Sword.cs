using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Sword : MonoBehaviour
{
    public Player player;
    public PlayerData playerData;
    public PlayerState PlayerState;
    public PlayerAbilityState PlayerAbilityState;
    public PlayerGroundedState PlayerGroundedState;
    public PlayerAttackLightState PlayerAttackLightState;

    public SO_WeaponData weaponData;
    public SO_AggressiveWeaponData aggressiveWeaponData;

    private Animator animator;


    private List<IDamageable> detectedDamageables = new List<IDamageable>();
    private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable>();
    public BoxCollider2D boxCollider2D;

    protected int attackModifier;
    private float attackFirstFrame;
    public float attackWindowTime = 10.0f;
    private float attackWindow;

    private bool lightAttack;
    private bool hardAttack;

    private bool isGrounded;


    protected int xInput;
    protected int yInput;



    public void Awake()
    {
        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
        //if (weaponData.GetType() == typeof(SO_AggressiveWeaponData))
        //{
        //    aggressiveWeaponData = (SO_AggressiveWeaponData)weaponData;
        //}
        //else
        //{
        //    Debug.LogError("Wrong data for the Weapon");
        //}
    }
    public virtual void EnterSword()
    {
        gameObject.SetActive(true);

        yInput = player.InputHandler.NormInputY;
        xInput = player.InputHandler.NormInputX;
        isGrounded = player.CheckIfGrounded();

        lightAttack = player.AttackLightState.lightAttack;
        hardAttack = player.AttackHardState.hardAttack;
        
        if(lightAttack)
            attackModifier = player.AttackLightState.attackModifier;
        else
            attackModifier = player.AttackHardState.attackModifier;

        animator.SetBool("lightAttack", lightAttack);
        animator.SetBool("hardAttack", hardAttack);
        animator.SetInteger("attackModifier", attackModifier);

        Debug.Log(isGrounded);

        if (yInput == -1 && isGrounded)
        { 
            if(lightAttack)
                attackModifier = 2;
            else if(hardAttack)
                attackModifier = 5;
            animator.SetInteger("attackModifier", attackModifier);
        }
        else if (!isGrounded)
        {
            if (lightAttack)
                attackModifier = 1;
            else if (hardAttack)
                attackModifier = 4;
            animator.SetInteger("attackModifier", attackModifier);
        }

    }

    public virtual void ExitSword()
    {
        hardAttack = false;
        lightAttack = false;
        attackModifier = 0;
        animator.SetBool("hardAttack", hardAttack);
        animator.SetBool("lightAttack", lightAttack);
        animator.SetInteger("attackModifier", attackModifier);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerEnter2D AddWorks");
        AddToDetected(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerExit2D RemoveWorks");
        RemoveFromDetected(collision);
    }

    public void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggressiveWeaponData.AttackDetails[attackModifier];

        foreach (IDamageable item in detectedDamageables.ToList())
        {
            item.Damage(details.damageAmount);
            Debug.Log(item);

        }

        foreach (IKnockbackable item in detectedKnockbackables.ToList())
        {
            item.Knockback(details.knockbackAngle, details.knockbackStrength, player.FacingDirection);
        }
    }

    public void AddToDetected(Collider2D collision)
    {
        //Debug.Log("[AggresiveWeapon]AddToDetected Works");

        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            //Debug.Log("[AggresiveWeapon] IF(damageable !=null) | AddToDetected Works");

            detectedDamageables.Add(damageable);
            Debug.Log("Added to the list");
        }
        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if (knockbackable != null)
        {
            detectedKnockbackables.Add(knockbackable);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        //Debug.Log("[AggresiveWeapon] RemoveToDetected Works");

        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageables.Remove(damageable);
            Debug.Log("Removed from the list");
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if (knockbackable != null)
        {
            detectedKnockbackables.Remove(knockbackable);
        }
    }

    public  void AnimationTrigger()
    {
        CheckMeleeAttack();
    }
    public void AnimationFinished_Sword() {

        if (hardAttack)
        {
            player.AttackHardState.AnimationFinishTrigger();
            Debug.Log("Animation Finished Trigger HardAttack");
        }
        else if (lightAttack)
            player.AttackLightState.AnimationFinishTrigger();
    }
}

