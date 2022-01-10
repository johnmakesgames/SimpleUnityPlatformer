using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableInfo : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private Rigidbody2D rigidBody;

    public Vector2 movementDirection;


    // Start is called before the first frame update
    void Start()
    {
        if (rigidBody == null)
        {
            var rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rigidBody = rb;
            }
            else
            {
                rigidBody = this.gameObject.AddComponent<Rigidbody2D>();
            }
        }
    }

    // Update is called once per    frame
    void FixedUpdate()
    {
        ApplyMovement();
    }

    public void ApplyMovement()
    {
        rigidBody.AddForce(movementDirection * movementSpeed);
    }
}
