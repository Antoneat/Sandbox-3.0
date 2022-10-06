using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sangrado : MonoBehaviour
{
    private PlayerDmg playerDmg;
    public BuscadorController buscadorController;

    public float danoSangrado;

    private bool sangrando;

    public float timerAtq = 1;


    void Start()
    {
        danoSangrado = 0.5f;

        sangrando = false;
    }


    void Update()
    {
        playerDmg = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDmg>();

        if(buscadorController.ataco == true)
        {
            ManagerTimerMain();
        }

        if(buscadorController.ataco == false)
        {
            sangrando = false;
        }
    }

    public void ManagerTimerMain()
    {
        sangrando = true;

        if (sangrando == true)
        {
            timerAtq -= Time.deltaTime;
        }

        if (timerAtq <= 0)
        {
            timerAtq = 1;
            BajarVida();
        }
    }

    private void BajarVida()
    {
        playerDmg.actualvida -= danoSangrado;
    }
}
