using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BuscadorConfig : MonoBehaviour
{
    public VariableManagerBuscador managerBuscador;

    [Header("variables")]
    public float awareAI_Conf;
    public float atkRange_Conf;

    [Header("Textos")]
    public TMP_Text text_AwareAi;
    public TMP_Text text_AtqRange;

    private void Awake()
    {
        awareAI_Conf = managerBuscador.awareAI_SO;
        atkRange_Conf = managerBuscador.atkRange_SO;
    }

    public void Start()
    {
        text_AwareAi.text = "AwareAI:" + awareAI_Conf;
        text_AtqRange.text = "AtqRange:" + atkRange_Conf;
    }

    public void Update()
    {
        managerBuscador.awareAI_SO = awareAI_Conf;
        managerBuscador.atkRange_SO = atkRange_Conf;
    }


    #region AwareAi
    public void MenosUnoAwareAi()
    {
        awareAI_Conf--;

        text_AwareAi.text = "AwareAI:" + awareAI_Conf;
        managerBuscador.awareAI_SO = awareAI_Conf;
    }
    public void ChangeAwareAI(string awareAI)
    {
        int awareAINew = Int32.Parse(awareAI);
        awareAI_Conf = awareAINew;

        text_AwareAi.text = "AwareAI:" + awareAI;

        managerBuscador.awareAI_SO = awareAINew;
    }
    public void MasUnoAwareAi()
    {
        awareAI_Conf++;

        text_AwareAi.text = "AwareAI:" + awareAI_Conf;
        managerBuscador.awareAI_SO = awareAI_Conf;
    }
    #endregion

    #region Ataque Range
    public void MenosUnoAtqRange()
    {
        atkRange_Conf--;

        text_AtqRange.text = "AtqRange:" + atkRange_Conf;
        managerBuscador.atkRange_SO = atkRange_Conf;
    }
    public void ChangeAtqRange(string atqRange)
    {
        int atqRangeNew = Int32.Parse(atqRange);
        atkRange_Conf = atqRangeNew;

        text_AtqRange.text = "AtqRange:" + atqRange;

        managerBuscador.atkRange_SO = atqRangeNew;
    }

    public void MasUnoAtqRange()
    {
        atkRange_Conf++;

        text_AtqRange.text = "AtqRange:" + atkRange_Conf;
        managerBuscador.atkRange_SO = atkRange_Conf;
    }
    #endregion
}
