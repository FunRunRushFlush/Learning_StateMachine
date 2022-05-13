using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessCollision(collision.gameObject);
    }
    //private void OnCollisionEnter2D(Collision2D collision2)
    //{
    //    ProcessCollision(collision2.gameObject);
    //}




    void ProcessCollision(GameObject collider)
    {
        if (collider.gameObject.TryGetComponent<Enemy>(out Enemy enmyComponent))
        {
            enmyComponent.TakeDamage(20);
        }
    }

}  
