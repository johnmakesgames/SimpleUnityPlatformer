using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    public void TakeDamage()
    {
        this.GetComponent<Animator>()?.SetTrigger("DamageTaken");
    }
}
