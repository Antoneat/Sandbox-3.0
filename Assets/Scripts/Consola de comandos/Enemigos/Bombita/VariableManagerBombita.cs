using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ManagerBombitaSO", menuName = "Data/VariablesBombita", order = 1)]
public class VariableManagerBombita : ScriptableObject
{
    public BombController bombController;

    //public GameObject prefabBombita;

    //public Transform transformRangoExplosion; //los 3 valores deben ser modificados por rangoExplosion

    public float awareAI_SO;
    public float atkRange_SO;

    //public float rangoExplosion_SO;
    public void Awake()
    {
        //transformRangoExplosion = prefabBombita.GetComponentInChildren<Transform>();

        //rangoExplosion_SO = transformRangoExplosion.localScale.x;

        awareAI_SO = bombController.awareAI;
        atkRange_SO = bombController.atkRange;
    }

    public void OnValidate()
    {
        //rangoExplosion_SO = transformRangoExplosion.localScale.x;

        awareAI_SO = bombController.awareAI;
        atkRange_SO = bombController.atkRange;
    }
}
