using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrisalidaDeAlmas : MonoBehaviour
{
    private PlayerDmg playerDmg;

    void Start()
    {
        playerDmg = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDmg>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Guadana"))
        {
            playerDmg.actualvida += 2.5f;
            Destroy(this.gameObject);
        }
    }
}
