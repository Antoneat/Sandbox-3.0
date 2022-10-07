using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BuscadorConfig : MonoBehaviour
{
    public VariableManagerBuscador managerBuscador;

    [Header("variables")]
    public float playerDistance_Conf;
    public float awareAI_Conf;
    public float atkRange_Conf;

    [Header("Textos")]
    public TMP_Text text_plyrDistance;
    public TMP_Text text_AwareAi;
    public TMP_Text text_AtqRange;

    private void Awake()
    {
        playerDistance_Conf = managerBuscador.playerDistance_SO;
        awareAI_Conf = managerBuscador.awareAI_SO;
        atkRange_Conf = managerBuscador.atkRange_SO;
    }

    public void Start()
    {
        text_plyrDistance.text = "PlyerDistance:" + playerDistance_Conf;
        text_AwareAi.text = "AwareAI:" + awareAI_Conf;
        text_AtqRange.text = "AtqRange:" + atkRange_Conf;
    }

    public void Update()
    {
        managerBuscador.playerDistance_SO = playerDistance_Conf;
        managerBuscador.awareAI_SO = awareAI_Conf;
    }

    #region PlayerDistance
    public void MasUnoPlayerDistance()
    {
        playerDistance_Conf++;

        text_plyrDistance.text = "PlyerDistance:" + playerDistance_Conf;
        managerBuscador.playerDistance_SO = playerDistance_Conf;
    }
    public void ChangePlayerDistance(string plyrDistance)
    {
        int plyrDistanceNew = Int32.Parse(plyrDistance);
        playerDistance_Conf = plyrDistanceNew;

        text_plyrDistance.text = "PlyerDistance:" + plyrDistance;

        managerBuscador.playerDistance_SO = plyrDistanceNew;
    }
    public void MenosUnoPlayerDistance()
    {
        playerDistance_Conf--;

        text_plyrDistance.text = "PlyerDistance:" + playerDistance_Conf;
        managerBuscador.playerDistance_SO = playerDistance_Conf;
    }
    #endregion

    #region AwareAi
    public void MasUnoAwareAi()
    {
        awareAI_Conf++;

        text_AwareAi.text = "AwareAI:" + awareAI_Conf;
        managerBuscador.awareAI_SO = awareAI_Conf;
    }
    #endregion
}
