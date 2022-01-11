using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    public int movementSpeed;
    public bool grounded;
    public bool hasSword;

    [SerializeField]
    Animator animationController;

    public void Start()
    {
        hasSword = true;

        if (animationController == null)
        {
            animationController = this.GetComponent<Animator>();
        }
    }   

    public void Update()
    {
        animationController.SetFloat("MovingSpeed", movementSpeed);
        animationController.SetBool("Grounded", grounded);
    }

    public void AttackEvent()
    {
        animationController.SetTrigger("Attack");
    }

    public void ThrowSword()
    {
        hasSword = false;
        animationController.SetBool("HasSword", hasSword);
        animationController.SetTrigger("ThrowSword");
    }

    public void PickupSword()
    {
        hasSword = true;
        animationController.SetBool("HasSword", hasSword);
        animationController.SetTrigger("PickupSword");
    }

    public void DamageTaken()
    {
        animationController.SetTrigger("DamageTaken");
    }
}
