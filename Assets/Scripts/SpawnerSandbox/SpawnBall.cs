using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject enemy;

    public Vector3 tpBicho;

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
            Instantiate(enemy, tpBicho, Quaternion.identity);
            enemy.SetActive(true);
        }

       
    }
}
