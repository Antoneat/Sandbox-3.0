using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public VariableManagerBombita managerBombita;
    public VariableManagerBuscador managerBuscador;
    public VariableManagerVerdugo managerVerdugo;

    public float life;
    public float maxLife;

    public float healAmount;
    public bool isBomb;

    public int soulAmount;


    private void Start()
    {
        maxLife = life;

        //AGITADOR
        ChangeLifeAgitador();
        ChangeHealtAmountAgitador();
        ChangeSoulAmountAgitador();

        managerBombita.OnValueChange += ChangeLifeAgitador;
        managerBombita.OnValueChange += ChangeHealtAmountAgitador;
        managerBombita.OnValueChange += ChangeSoulAmountAgitador;

        /*BUSCADOR
        ChangeLifeBuscador();
        ChangeHealtAmountBucador();
        ChangeSoulAmountBuscador();

        managerBuscador.OnValueChange += ChangeLifeBuscador;
        managerBuscador.OnValueChange += ChangeHealtAmountBucador;
        managerBuscador.OnValueChange += ChangeSoulAmountBuscador;

        //VERDUGO

        ChangeLifeVerdugo();
        ChangeHealtAmountVerdugo();
        ChangeSoulAmountVerdugo();

        managerVerdugo.OnValueChange += ChangeLifeVerdugo;
        managerVerdugo.OnValueChange += ChangeHealtAmountVerdugo;
        managerVerdugo.OnValueChange += ChangeSoulAmountVerdugo;*/
    }

    #region Agitador
    void ChangeLifeAgitador()
    {
        life = managerBombita.life_SO;
    }

    void ChangeHealtAmountAgitador()
    {
        healAmount = managerBombita.healAmount_SO;
    }

    void ChangeSoulAmountAgitador()
    {
        soulAmount = managerBombita.soulAmount_SO;
    }

    #endregion

    #region Buscador
    void ChangeLifeBuscador()
    {
        life = managerBuscador.life_SO;
    }

    void ChangeHealtAmountBucador()
    {
        healAmount = managerBuscador.healAmount_SO;
    }

    void ChangeSoulAmountBuscador()
    {
        soulAmount = managerBuscador.soulAmount_SO;
    }

    #endregion
    
    #region Verdugo
    void ChangeLifeVerdugo()
    {
        life = managerVerdugo.life_SO;
    }

    void ChangeHealtAmountVerdugo()
    {
        healAmount = managerVerdugo.healAmount_SO;
    }

    void ChangeSoulAmountVerdugo()
    {
        soulAmount = managerVerdugo.soulAmount_SO;
    }

    #endregion

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
