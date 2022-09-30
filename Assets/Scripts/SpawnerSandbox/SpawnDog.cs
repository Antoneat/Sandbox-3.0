using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDog : MonoBehaviour
{
    public GameObject enemy;

    public Vector3 tpBuscador;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("Player"))
        {
            Instantiate(enemy, tpBuscador, Quaternion.identity);
            enemy.SetActive(true);
        }


    }
}
