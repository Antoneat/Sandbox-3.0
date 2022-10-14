using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BombitaConfig : MonoBehaviour
{
    public VariableManagerBombita managerBombita;

    [Header("variables")]
    public float awareAI_Conf;
    public float atkRange_Conf;
    //public float rangoExplosion_Conf;

    [Header("Textos")]
    public TMP_Text text_AwareAi;
    public TMP_Text text_AtqRange;
    //public TMP_Text text_RangoExplosion;

    private void Awake()
    {
        awareAI_Conf = managerBombita.awareAI_SO;
        atkRange_Conf = managerBombita.atkRange_SO;
        //rangoExplosion_Conf = managerBombita.rangoExplosion_SO;
    }

    public void Start()
    {
        text_AwareAi.text = "AwareAI:" + awareAI_Conf;
        text_AtqRange.text = "AtqRange:" + atkRange_Conf;
        //text_RangoExplosion.text = "RngExplosion:" + rangoExplosion_Conf;
    }

    public void Update()
    {
        managerBombita.awareAI_SO = awareAI_Conf;
        managerBombita.atkRange_SO = atkRange_Conf;
        //managerBombita.rangoExplosion_SO = rangoExplosion_Conf;
    }


    #region AwareAi
    public void MenosUnoAwareAi()
    {
        awareAI_Conf--;

        text_AwareAi.text = "AwareAI:" + awareAI_Conf;
        managerBombita.awareAI_SO = awareAI_Conf;
    }
    public void ChangeAwareAI(string awareAI)
    {
        int awareAINew = Int32.Parse(awareAI);
        awareAI_Conf = awareAINew;

        text_AwareAi.text = "AwareAI:" + awareAI;

        managerBombita.awareAI_SO = awareAINew;
    }

    public void MasUnoAwareAi()
    {
        awareAI_Conf++;

        text_AwareAi.text = "AwareAI:" + awareAI_Conf;
        managerBombita.awareAI_SO = awareAI_Conf;
    }
    #endregion

    #region Ataque Range
    public void MenosUnoAtqRange()
    {
        atkRange_Conf--;

        text_AtqRange.text = "AtqRange:" + atkRange_Conf;
        managerBombita.atkRange_SO = atkRange_Conf;
    }
    public void ChangeAtqRange(string atqRange)
    {
        int atqRangeNew = Int32.Parse(atqRange);
        atkRange_Conf = atqRangeNew;

        text_AtqRange.text = "AtqRange:" + atqRange;

        managerBombita.atkRange_SO = atqRangeNew;
    }

    public void MasUnoAtqRange()
    {
        atkRange_Conf++;

        text_AtqRange.text = "AtqRange:" + atkRange_Conf;
        managerBombita.atkRange_SO = atkRange_Conf;
    }
    #endregion
    
    /*#region Rango Explosion
    public void MenosUnoRangoExplosion()
    {
        rangoExplosion_Conf--;

        text_RangoExplosion.text = "RngExplosion:" + rangoExplosion_Conf;
        managerBombita.rangoExplosion_SO = rangoExplosion_Conf;
    }
    public void ChangeRangoExplosion(string rngExplosion)
    {
        int rngExplosionNew = Int32.Parse(rngExplosion);
        rangoExplosion_Conf = rngExplosionNew;

        text_RangoExplosion.text = "RngExplosion:" + rngExplosion;

        managerBombita.rangoExplosion_SO = rngExplosionNew;
    }

    public void MasUnoRangoExplosion()
    {
        rangoExplosion_Conf++;

        text_RangoExplosion.text = "RngExplosion:" + rangoExplosion_Conf;
        managerBombita.rangoExplosion_SO = rangoExplosion_Conf;
    }
    #endregion*/
}
