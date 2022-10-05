using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ArenaDanoConfig : MonoBehaviour
{
    [Header("Referencias")]
    public ArenaAlmas arenaAlmas;

    [Header("Textos")]
    public TMP_Text text_dano;
    public TMP_Text text_tiempo;


    private float danoFloat;
    private float tiempoFloat;

    public void Awake()
    {
        danoFloat = arenaAlmas.danoArena;
        tiempoFloat = arenaAlmas.timerMain;
    }

    void Start()
    {
        text_dano.text = "Da�o:" + arenaAlmas.danoArena;
        text_tiempo.text = "Tiempo:" + arenaAlmas.timerMain;
    }

    #region Dano
    public void MasUnoDano()
    {
        danoFloat++;

        text_dano.text = "Da�o:" + danoFloat;

        arenaAlmas.danoArena = danoFloat;
    }
    public void ChangeDano(string danoAlma)
    {
        int danoAlmaNew = Int32.Parse(danoAlma);
        danoFloat = danoAlmaNew;

        text_dano.text = "Da�o:" + danoAlma;
    }
    public void MenosUnoDano()
    {
        danoFloat--;

        text_dano.text = "Da�o:" + danoFloat;

        arenaAlmas.timerMain = tiempoFloat;
    }

    #endregion
}
