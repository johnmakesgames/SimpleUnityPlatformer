using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0));
        }

        if (Input.GetKey(KeyCode.Space) && this.GetComponent<GroundedKnower>().IsGrounded)
        {
             this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100));
        }
    }
}
