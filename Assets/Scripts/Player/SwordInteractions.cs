using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordInteractions : MonoBehaviour
{
    private bool hasDoneDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        hasDoneDamage = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            var killableComponent = other.gameObject.GetComponent<Killable>();
            if (killableComponent)
            {
                if (!hasDoneDamage)
                {
                    killableComponent.TakeDamage();
                    hasDoneDamage = true;
                }
            }
            else
            {
                if (!other.gameObject.GetComponent<PlayerAnimController>())
                {
                    Destroy(this.GetComponent<Rigidbody2D>());
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerAnimController>()?.PickupSword();
            Destroy(this.gameObject);
        }
    }
}
