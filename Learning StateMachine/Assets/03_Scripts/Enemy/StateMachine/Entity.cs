using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public EnemyStateMachine stateMachine;
    public EnemyData enemyData;
    public Rigidbody2D rb { get; private set; }
    public Animator animator { get; private set; }
    public GameObject aliveGo { get; private set; }

    public int facingDirection { get; private set; }

    private Vector2 workspace;

    public Transform wallCheck;
    public Transform ledgeCheck;
    public Transform playerCheck;

    private void Awake()
    {
        stateMachine = new EnemyStateMachine();
    }

    public virtual void Start()
    {
        facingDirection = 1;

        aliveGo = transform.Find("Alive").gameObject;
        rb = aliveGo.GetComponent<Rigidbody2D>();
        animator = aliveGo.GetComponent<Animator>();
       


    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    { stateMachine.currentState.PhysicsUpdate(); }

    public virtual void SetVelocity(float velocity)
    {
        workspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = workspace;
    }

    public virtual bool CheckWall()
    {

        return Physics2D.OverlapCircle(wallCheck.position, enemyData.groundCheckRadius, enemyData.groundLayer);

    }

    public virtual bool CheckLedge()
    { 
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, enemyData.ledgeCheckDistance, enemyData.groundLayer); 
    }
    public virtual bool CheckPlayerInMinAggroRange()
    {
        return Physics2D.Raycast(playerCheck.position, Vector2.right, enemyData.minAggroDistance * facingDirection, enemyData.playerLayer);
    }
    public virtual bool CheckPlayerInMaxAggroRange()
    {
        return Physics2D.Raycast(playerCheck.position, Vector2.right, enemyData.maxAggroDistance * facingDirection, enemyData.playerLayer);
    }
    public virtual void Flip()
    {
        facingDirection *= -1;
        aliveGo.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawSphere(wallCheck.position, enemyData.groundCheckRadius);
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * enemyData.ledgeCheckDistance));
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + (Vector3)(Vector2.right * enemyData.minAggroDistance * facingDirection));
        Gizmos.DrawLine(playerCheck.position, playerCheck.position + (Vector3)(Vector2.right * enemyData.maxAggroDistance * facingDirection));
    }
}
