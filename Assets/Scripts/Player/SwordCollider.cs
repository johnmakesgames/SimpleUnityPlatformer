using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    Vector3 collisionOffsetRight;

    [SerializeField]
    Vector3 collisionOffsetLeft;

    public List<Collider2D> collidingObjects = new List<Collider2D>();

    // Update is called once per frame
    void Update()
    {
        bool facingRight = player.GetComponent<PlayerMovementHandler>()?.facingRight ?? false;

        if (facingRight)
        {
            this.transform.position = player.transform.position + collisionOffsetRight;
        }
        else
        {
            this.transform.position = player.transform.position + collisionOffsetLeft;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collidingObjects.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collidingObjects.Remove(collision);
    }
}
