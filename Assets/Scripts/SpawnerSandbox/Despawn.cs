using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public List<GameObject> enemies1;
    public List<GameObject> enemies2;

    void Start()
    {
        enemies1 = new List<GameObject>();
        enemies2 = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        enemies1.AddRange(GameObject.FindGameObjectsWithTag("Bombita"));
        enemies2.AddRange(GameObject.FindGameObjectsWithTag("Buscador"));
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("Player"))
        {
            foreach (GameObject Bombita in enemies1)
            {
                Destroy(Bombita);
            }

        }

        if (collider.gameObject.CompareTag("Player"))
        {
            foreach (GameObject Buscador in enemies2)
            {
                Destroy(Buscador);
            }

        }
    }
}

