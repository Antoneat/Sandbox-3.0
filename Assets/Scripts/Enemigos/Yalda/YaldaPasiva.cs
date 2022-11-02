using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class YaldaPasiva : MonoBehaviour
{
    private YaldaVida yaldaVida;

    public float cooldownGeneral;
    private float cooldownToSpawnA, cooldownToSpawnB, cooldownToSpawnV;

    [Header("Enemigos")]
    public List<GameObject> agitador, buscador, verdugo;
    public GameObject agitadorPrefab, buscadorPrefab, verdugoPrefab;

    void Start()
    {
        yaldaVida = GetComponent<YaldaVida>();
        cooldownToSpawnA = cooldownToSpawnB = cooldownToSpawnV = cooldownGeneral;
    }

    void Update()
    {
        if(yaldaVida.actualVida <= 40)
        {
            InvokeRepeating(nameof(SpawnerAleatorio), 1f, 1f);
        }

        if(cooldownToSpawnA >= 0)
        {
            cooldownToSpawnA -= Time.deltaTime;
        }
        if(cooldownToSpawnB >= 0)
        {
            cooldownToSpawnB -= Time.deltaTime;
        }
        if(cooldownToSpawnV >= 0)
        {
            cooldownToSpawnV -= Time.deltaTime;
        }
        
    }

    public void SpawnerAleatorio()
    {   
        Vector3 randomSpawnPositionA = new Vector3(UnityEngine.Random.Range(-10, 11), 1, UnityEngine.Random.Range(-10, 11)); //CAMBIAR POR LAS DIMENSIONES DE LA SALA DE YALDA
        Vector3 randomSpawnPositionB = new Vector3(UnityEngine.Random.Range(-10, 11), 1, UnityEngine.Random.Range(-10, 11)); //CAMBIAR POR LAS DIMENSIONES DE LA SALA DE YALDA
        Vector3 randomSpawnPositionV = new Vector3(UnityEngine.Random.Range(-10, 11), 1, UnityEngine.Random.Range(-10, 11)); //CAMBIAR POR LAS DIMENSIONES DE LA SALA DE YALDA

        if(agitador.Count <= 8 && cooldownToSpawnA <= 0)
        {
            cooldownToSpawnA = cooldownGeneral;
            Instantiate(agitadorPrefab, randomSpawnPositionA, Quaternion.identity);
            agitador.Add(agitadorPrefab);
        }

        if(buscador.Count <= 2 && cooldownToSpawnB <= 0)
        {
            cooldownToSpawnB = cooldownGeneral;
            Instantiate(buscadorPrefab, randomSpawnPositionB, Quaternion.identity);
            buscador.Add(buscadorPrefab);
        }

        if(verdugo.Count <= 1 && cooldownToSpawnV <= 0)
        {
            cooldownToSpawnV = cooldownGeneral;
            Instantiate(verdugoPrefab, randomSpawnPositionV, Quaternion.identity);
            verdugo.Add(verdugoPrefab);
        }
    }
}
