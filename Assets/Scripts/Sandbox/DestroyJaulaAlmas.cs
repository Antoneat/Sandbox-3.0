
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyJaulaAlmas : MonoBehaviour
{
    private SpawnJaulaAlmas spawnJaulaAlmas;
    void Start()
    {
        spawnJaulaAlmas = GameObject.FindGameObjectWithTag("SpawJaulaAlmas").GetComponent<SpawnJaulaAlmas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Guadana"))
        {
            Destroy(this.gameObject);
            spawnJaulaAlmas.jaulaIsActive = false;
        }
    }
}
