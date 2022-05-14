using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected SO_WeaponData weaponData;


    protected Animator weaponAnimator;

    protected PlayerAttackLightState state;



    protected int attackCounter;

    protected virtual void Awake()
    {

        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        if (attackCounter >= weaponData.amountOfAttacks)
        {
            attackCounter = 0;
        }


        weaponAnimator.SetBool("attack", true);


        weaponAnimator.SetInteger("attackCounter", attackCounter);
    }

    public virtual void ExitWeapon()
    {

        weaponAnimator.SetBool("attack", false);

        attackCounter++;

        gameObject.SetActive(false);
    }

    #region Animation Triggers

    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }

    //public virtual void AnimationStartMovementTrigger()
    //{
    //    state.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);
    //}

    //public virtual void AnimationStopMovementTrigger()
    //{
    //    state.SetPlayerVelocity(0f);
    //}

    //public virtual void AnimationTurnOffFlipTrigger()
    //{
    //    state.SetFlipCheck(false);
    //}

    //public virtual void AnimationTurnOnFlipTigger()
    //{
    //    state.SetFlipCheck(true);
    //}

    public virtual void AnimationActionTrigger() { }

    #endregion

    public void InitializeWeapon(PlayerAttackLightState state)
    {
        this.state = state;
    }

}
