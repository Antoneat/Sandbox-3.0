using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJaulaAlmas : MonoBehaviour
{
    public bool jaulaIsActive;

    public GameObject jaulaPrefab;

    public Transform spawnPoint;

    public float timerMain = 3;

    void Start()
    {

    }

    void Update()
    {
        if (!jaulaIsActive)
        {
            timerMain -= Time.deltaTime;

            if (timerMain <= 0)
            {
                Instantiate(jaulaPrefab, spawnPoint.position, spawnPoint.rotation);
                jaulaIsActive = true;
                timerMain = 5;
            }
        }
    }
}
