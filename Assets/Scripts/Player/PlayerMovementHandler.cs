using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField]
    GameObject swordPrefab;

    [SerializeField]
    GameObject swordCollider;

    public bool facingRight;

    private float jumpCooldown = 1;
    private float timeSinceJump = 0;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0));
            facingRight = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0));
            facingRight = false;
        }

        if (Input.GetKey(KeyCode.Space) && this.GetComponent<GroundedKnower>().IsGrounded && timeSinceJump > jumpCooldown)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 150));
            timeSinceJump = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceJump += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && this.GetComponent<PlayerAnimController>().hasSword)
        {
            this.GetComponent<PlayerAnimController>().AttackEvent();

            var enemyColliders = swordCollider.GetComponent<SwordCollider>().collidingObjects.Where(x => x.tag == "Enemy").ToList();
            foreach (var enemy in enemyColliders)
            {
                enemy.GetComponent<Killable>()?.TakeDamage();

                Vector2 knockback = (facingRight) ? new Vector2(1, 1) : new Vector2(-1, 1);
                enemy.GetComponent<Rigidbody2D>()?.AddForce(knockback * this.gameObject.GetComponent<SwoirdStats>().knockbackForce);
            }
        }

        if (Input.GetMouseButtonDown(1) && this.GetComponent<PlayerAnimController>().hasSword)
        {
            this.GetComponent<PlayerAnimController>().ThrowSword();
            float width = this.GetComponent<Collider2D>().bounds.extents.x;
            Vector3 facingDirection = (facingRight) ? new Vector3(1, 0, 0) : new Vector3(-1, 0, 0);

            var spawnedSword = Instantiate(swordPrefab, this.transform.position + (facingDirection * 0.25f), this.transform.rotation);
            spawnedSword.GetComponent<Rigidbody2D>().AddForce(facingDirection * ((50 * this.gameObject.GetComponent<SwoirdStats>().throwForce)));

            if (!facingRight)
            {
                spawnedSword.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}