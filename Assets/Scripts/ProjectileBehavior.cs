using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private float lifetime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(transform, lifetime);
    }    
}
