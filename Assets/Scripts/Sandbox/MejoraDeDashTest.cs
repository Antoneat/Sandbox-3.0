using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraDeDashTest : MonoBehaviour
{
    private PlayerDash playerDash;
    
    void Update()
    {
        playerDash = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDash>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDash.upgradeDash = !playerDash.upgradeDash ;
        }
    }
}
