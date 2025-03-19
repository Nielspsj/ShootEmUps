using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    private int health = 10;
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        //scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            //scoreManager.EnemyKilled();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");

        if (collision.transform.tag == "Projectile")
        {
            health -= 5;
        }

    }
}
