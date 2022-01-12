using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedKnower : MonoBehaviour
{
    public bool IsGrounded;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject != this.gameObject)
        {
            IsGrounded = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != this.gameObject)
        {
            IsGrounded = false;
        }
    }
}
