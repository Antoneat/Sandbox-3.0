using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ManagerVerdugoSO", menuName = "Data/VariablesVerdugo", order = 1)]
public class VariableManagerVerdugo : ScriptableObject
{
    public VerdugoController verdugoController;

    public float awareAI_SO;
    public float atkRange_SO;
    public void Awake()
    {
        awareAI_SO = verdugoController.awareAI;
        atkRange_SO = verdugoController.atkRange;
    }

    public void OnValidate()
    {
        awareAI_SO = verdugoController.awareAI;
        atkRange_SO = verdugoController.atkRange;
    }
}
