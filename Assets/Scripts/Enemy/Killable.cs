using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    public int health;

    public void TakeDamage()
    {
        this.GetComponent<Animator>()?.SetTrigger("DamageTaken");

        health--;
    }
}
