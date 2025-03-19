using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public int damage = 1;

    //Check if the trigger hits an object with the tag enemy.
    //Have it take damage using its own method. We just send the damage amount to it.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            collision.GetComponent<EnemyBehavior>().TakeDamage(damage);
        }
    }
}
