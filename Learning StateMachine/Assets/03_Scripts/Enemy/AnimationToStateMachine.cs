using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
    public EnemyAttackState attackState;
    public E1_Enemy entity;
    public void TriggerAttack()
    {
        
        attackState.TriggerAttack();
    }

    public void FinishAttack()
    {
        attackState.FinishAttack();
    }
}
