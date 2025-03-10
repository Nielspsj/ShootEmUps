using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShootingController2D : MonoBehaviour
{
    public GameObject projectilePref;
    public float speed = 10f;
    private Vector3 mousePosition;
    private Vector3 mouseDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Debug.Log("mousepos: " + mousePosition);
        mouseDirection = (mousePosition - transform.position).normalized;
        if (Input.GetMouseButtonDown(0))
        {            
            GameObject projectile = Instantiate(projectilePref, transform.position, transform.rotation) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(mouseDirection.x * speed, mouseDirection.y * speed);
        }
    }
}
