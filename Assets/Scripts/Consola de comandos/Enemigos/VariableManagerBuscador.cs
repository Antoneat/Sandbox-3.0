using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ManagerBuscadorSO", menuName = "Data/VariablesBuscador", order = 1)]
public class VariableManagerBuscador : ScriptableObject
{
    public BuscadorController buscadorController;

    public float playerDistance_SO;
    public float awareAI_SO;
    public float atkRange_SO;

    public void Awake()
    {
        playerDistance_SO = buscadorController.playerDistance;
        awareAI_SO = buscadorController.awareAI;
        atkRange_SO = buscadorController.atkRange;
    }

    public void OnValidate()
    {
        playerDistance_SO = buscadorController.playerDistance;
        awareAI_SO = buscadorController.awareAI;
        atkRange_SO = buscadorController.atkRange;
    }
}
