using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public VariableManagerBuscador managerBuscador;

    public float life;
    public float maxLife;

    public float healAmount;
    public bool isBomb;

    public int soulAmount;


    private void Start()
    {
        ChangeLifeBuscador();

        maxLife = life;

        managerBuscador.OnValueChange += ChangeLifeBuscador;
    }

    void ChangeLifeBuscador()
    {
        life = managerBuscador.life_SO;
    }

    public void TakeDmg(float dmg)
    {
        life -= dmg;

        if(life <= 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerDmg>().GainLife(healAmount);

            if (!isBomb)
            {
                player.GetComponent<PlayerDmg>().GainSoul(soulAmount);
            }

            Destroy(gameObject);
        }
    }
}
