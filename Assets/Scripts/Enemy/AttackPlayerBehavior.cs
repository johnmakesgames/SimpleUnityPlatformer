using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerBehavior : MonoBehaviour, EnemyBehavior
{
    public EnemyInfo enemyInfo = null;
    public float attackForce = 0;
    public bool recentlyAttacked = false;
    public float attackCooldown = 0;
    public float timeSinceAttack = 0;
    public float attackFrameTime = 0.9f;

    void Start()
    {
        enemyInfo = this.GetComponent<EnemyInfo>();
    }

    public void EnterState()
    {
        // Nothing to do on enter
    }

    public void Act()
    {
        Vector2 attackDirection = GetMovingDirection();

        GetComponent<Animator>().SetTrigger("Attack");

        timeSinceAttack = 0;
        recentlyAttacked = true;
        StartCoroutine(WaitAndAttack(0.35f, attackDirection));
    }

    private IEnumerator WaitAndAttack(float waitTime, Vector2 attackDirection)
    {
        yield return new WaitForSeconds(waitTime);
        var rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(attackForce * attackDirection.x, 0));
    }

    public void ExitState()
    {
        // Nothing to do on exit
    }

    public bool CanEnterBehavior()
    {
        if (recentlyAttacked)
        {
            timeSinceAttack += Time.deltaTime;

            if (timeSinceAttack > attackCooldown)
            {
                recentlyAttacked = false;
            }

            return false;
        }

        Vector2 movingDirection = GetMovingDirection();
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + (enemyInfo.characterOffset * movingDirection.x), transform.position.y), movingDirection, enemyInfo.attackRange);

        if (hit.rigidbody == null)
        {
            return false;
        }
        else if (hit.rigidbody?.gameObject?.tag != "Player")
        {
            return false;
        }

        return true;
    }

    private Vector2 GetMovingDirection()
    {
        var wander = GetComponent<WanderBehavior>();
        if (wander)
        {
            return wander.movingDirection;
        }
        else
        {
            return new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (timeSinceAttack < attackFrameTime)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Killable>().TakeDamage();
            }    
        }
    }

}
