using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    public int movementSpeed;
    public bool grounded;

    [SerializeField]
    Animator animationController;

    public void Start()
    {
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
        animationController.SetTrigger("ThrowSword");
    }

    public void PickupSword()
    {
        animationController.SetTrigger("PickupSword");
    }

    public void DamageTaken()
    {
        animationController.SetTrigger("DamageTaken");
    }
}
