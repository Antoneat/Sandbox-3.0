using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    agitador, 
    buscador, 
    verdugo,
}

public class EnemyHitbox : MonoBehaviour
{
    //public VariableManagerBombita managerBombita;
    //public VariableManagerBuscador managerBuscador;
    //public VariableManagerVerdugo managerVerdugo;

    public float dmg; // Cantidad de dmg dado para el player.
    public float modifier = 1f;
    public EnemyType enemyType;

    /*private void Start()
    {
        //AGITADOR
        ChangeDmgAgitador();
        managerBombita.OnValueChange += ChangeDmgAgitador;

        //BUSCADOR
        ChangeDmgBuscador();
        managerBuscador.OnValueChange += ChangeDmgBuscador;

        //VERDUGO
        ChangeDmgVerdugo();
        managerVerdugo.OnValueChange += ChangeDmgVerdugo;
    }*/
    void Update()
    {
        if(enemyType == EnemyType.buscador)
        {
            GameObject player = GameObject.FindGameObjectWithTag("PlayerPivot");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 15f * Time.deltaTime);

            //this.gameObject.GetComponent<Rigidbody>().MovePosition(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerDmg>() && other.gameObject.CompareTag("Player"))
        {
            if(modifier != 0)
            {
                other.gameObject.GetComponent<PlayerDmg>().LoseLife(dmg * modifier);
            }
            else
            {
                other.gameObject.GetComponent<PlayerDmg>().LoseLife(dmg);
            }

            if (enemyType == EnemyType.buscador)
            {
                Destroy(gameObject, 1.5f);
            }

            if (enemyType == EnemyType.verdugo)
            {
                // crear la inmovilizacion PARA FRANCIS 
                Destroy(gameObject);
            }
        }

        if (enemyType == EnemyType.agitador)
        {
            if (other.gameObject.CompareTag("Bombita"))
            {
                other.gameObject.GetComponent<BombController>().basicoGO.GetComponent<EnemyHitbox>().modifier += 2f;
            }
        }
    }

    /*#region CambiarDano
    void ChangeDmgAgitador()
    {
        dmg = managerBombita.life_SO;
    }

    void ChangeDmgBuscador()
    {
        dmg = managerBuscador.life_SO;
    }

    void ChangeDmgVerdugo()
    {
        dmg = managerVerdugo.life_SO;
    }

    #endregion*/
}
