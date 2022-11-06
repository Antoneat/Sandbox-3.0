using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaGuadana : MonoBehaviour
{
    private PlayerDmg playerDmg;
    private SpawCrisalida spawCrisalida;
    private SpawnJaulaAlmas spawnJaulaAlmas;
    void Start()
    {
        playerDmg = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDmg>();
        spawCrisalida = GameObject.FindGameObjectWithTag("SpawCrisalida").GetComponent<SpawCrisalida>();
        spawnJaulaAlmas = GameObject.FindGameObjectWithTag("SpawJaulaAlmas").GetComponent<SpawnJaulaAlmas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JaulaAlmas"))
        {
            Destroy(this.gameObject);
            spawnJaulaAlmas.jaulaIsActive = false;
        }

        if (other.CompareTag("Crisalida"))
        {
            playerDmg.actualvida += 2.5f;
            Destroy(this.gameObject);
            spawCrisalida.crisalidaIsActive = false;
        }
    }

}
