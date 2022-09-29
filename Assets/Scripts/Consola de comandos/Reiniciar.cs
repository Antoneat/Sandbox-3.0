using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reiniciar : MonoBehaviour
{

    public GameObject scarletPrefab;

    public Transform spawnScarlet;

    public ConsolaComandosManager consolaComandos;


    public void ReinciarScarlet()
    {
        consolaComandos.panelReinicio.SetActive(false);
        Instantiate(scarletPrefab, spawnScarlet.position, spawnScarlet.rotation);
    }
}
