using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedKnower : MonoBehaviour
{
    public bool IsGrounded
    {
        get
        {
            Transform transform = this.GetComponent<Transform>();
            RaycastHit2D hit = Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), 
                                new Vector2(transform.position.x, transform.position.y - 0.1f) + new Vector2(0, -0.01f), 0);

            if (hit.collider != null)
            {
                return true;
            }

            return false;
        }
    }
}
