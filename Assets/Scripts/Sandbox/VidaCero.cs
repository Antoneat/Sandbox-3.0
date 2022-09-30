using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaCero : MonoBehaviour
{
    private PlayerDmg playerDmg;

    public float danoTotalCero;

    private bool pisandoTotalCero;

    public float timerMain = 1;


    void Start()
    {
        

        danoTotalCero = 4f;

        pisandoTotalCero = false;
    }


    void Update()
    {
        playerDmg = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDmg>();

        if (pisandoTotalCero == true)
        {
            timerMain -= Time.deltaTime;
        }

        if (timerMain <= 0)
        {
            timerMain = 1;
            BajarVida();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pisandoTotalCero = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pisandoTotalCero = false;
        }
    }

    private void BajarVida()
    {
        playerDmg.actualvida -= danoTotalCero;
    }
}
