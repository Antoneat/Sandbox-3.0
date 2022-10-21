using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image barraVida;

    public PlayerDmg playerDmg;

    public float vidaActual;

    public float vidaMax;

    void Update()
    {
        playerDmg = FindObjectOfType<PlayerDmg>();

        vidaActual = playerDmg.actualvida;

        vidaMax = playerDmg.maxVida;

        barraVida.fillAmount = vidaActual / vidaMax;
    }
}
