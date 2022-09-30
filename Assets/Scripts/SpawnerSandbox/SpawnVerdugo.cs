using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVerdugo : MonoBehaviour
{
    public GameObject enemy;

    public Vector3 tpVerdugo;

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
            Instantiate(enemy, tpVerdugo, Quaternion.identity);
            enemy.SetActive(true);
        }


    }
}
