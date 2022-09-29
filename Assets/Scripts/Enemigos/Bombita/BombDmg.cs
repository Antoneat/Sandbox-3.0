using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDmg : MonoBehaviour
{
    [Header("Vida")]
    public float vida;
    public bool dead;

    void Start()
    {
       // plyrDMG = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDmg>();
        vida = 5;
    }

    
    void Update()
    {
        MuerteBomba();
    }
    public void MuerteBomba()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("AtaqueNormal")) vida -= 2; // Baja la vida del enemigo acorde con el valor que se puso en el ataque.

        if (collider.gameObject.CompareTag("AtaqueDuro")) vida -= 4;// Lo de arriba x2.        
    }
}