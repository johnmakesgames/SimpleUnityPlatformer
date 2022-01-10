using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        this.GetComponent<PlayerAnimController>().movementSpeed = 0;

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            this.GetComponent<PlayerAnimController>().movementSpeed = 1;
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            this.GetComponent<PlayerAnimController>().movementSpeed = 1;
        }

        if (this.GetComponent<GroundedKnower>().IsGrounded)
        {
            this.GetComponent<PlayerAnimController>().grounded = true;
        }
        else
        {
            this.GetComponent<PlayerAnimController>().grounded = false;
        }
    }
}
