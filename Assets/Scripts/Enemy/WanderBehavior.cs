using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : MonoBehaviour, EnemyBehavior
{
    float movementSpeed = 10;
    Vector2 movingDirection = new Vector2(1, 0);
    EnemyInfo enemyInfo;

    void Start()
    {
        enemyInfo = this.GetComponent<EnemyInfo>();
    }

    public void EnterState()
    {
        //movingDirection = new Vector2(1, 0);
    }

    public void Act()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + (enemyInfo.characterOffset * movingDirection.x), transform.position.y), movingDirection, enemyInfo.scanRange);

        if (hit.collider == null)
        {
            var rb = this.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(movementSpeed * movingDirection.x, 0));
            Debug.Log(rb.velocity.magnitude);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, 1.2f);
        }
        else
        {
            movingDirection.x *= -1;
        }
    }
    

    public void ExitState()
    {
        
    }

    public bool CanEnterBehavior()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + (enemyInfo.characterOffset * movingDirection.x), transform.position.y), movingDirection, enemyInfo.attackRange);

        if (hit.collider == null)
        {
            return true;
        }
        else if (hit.rigidbody.gameObject.tag != "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}