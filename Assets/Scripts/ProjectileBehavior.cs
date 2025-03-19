using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private float lifetime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we hit an obstacle, destroy the projectile.
        //To prevent it getting destroyed as it spawns?
        if(collision.transform.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
