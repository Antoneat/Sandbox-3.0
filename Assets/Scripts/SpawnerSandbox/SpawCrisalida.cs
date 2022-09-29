using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawCrisalida : MonoBehaviour
{

    public bool crisalidaIsActive;

    public GameObject crisalidaPrefab;

    public Transform spawnPoint;

    public float timerMain = 5;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (!crisalidaIsActive)
        {           
            timerMain -= Time.deltaTime;

            if(timerMain <= 0)
            {
                Instantiate(crisalidaPrefab, spawnPoint.position, spawnPoint.rotation);
                crisalidaIsActive = true;
                timerMain = 5;
            }
        }
    }
}
