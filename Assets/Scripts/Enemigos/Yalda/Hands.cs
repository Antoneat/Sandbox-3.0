using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    [SerializeField] float speed;

    //public float damage;
    [SerializeField] float timeToDestroyObject;

    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        Destroy(this.gameObject, timeToDestroyObject);
    }

    
}