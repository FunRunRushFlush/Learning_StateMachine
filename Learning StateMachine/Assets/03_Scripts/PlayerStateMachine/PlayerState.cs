using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    protected bool isAnimationFinished;
    protected bool isGrounded;

    protected float startTime;  //referece how long beeing in one State

    private string animBoolName;

    protected Vector2 rawInput;    // all sub States have acces to this variable
    protected Vector2 normInput;    // all sub States have acces to this variable
    protected int xInput;       // all sub States have acces to this variable
    protected int yInput;       // all sub States have acces to this variable
    protected bool sprintInput; // all sub States have acces to this variable

  

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) 
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        player.Animator.SetBool(animBoolName, true);
        startTime = Time.time;
        Debug.Log(animBoolName);
        isAnimationFinished = false;
    }
    public virtual void Exit()
    {
        player.Animator.SetBool(animBoolName, false);
    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    public virtual void DoChecks()
    {

    }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
