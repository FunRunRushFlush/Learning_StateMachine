using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToStateMachine : MonoBehaviour
{
    public Collider2D capsuleCollider;
    public E1_MeleeAttackState meleeAttackState;
    public E1_Enemy enemy;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerEnter2D AddWorks");
        enemy.meleeAttackState.AddToDetected(collision);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerExit2D RemoveWorks");
        enemy.meleeAttackState.RemoveFromDetected(collision);
    }
}
