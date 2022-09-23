using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDmg : MonoBehaviour
{
    [Header("Vida")]
    public float actualvida;
    private float maxVida = 30f;

    private BombDmg Bdmg;
    private DmgController dmgC;

    void Start()
    {
        Bdmg = GameObject.FindGameObjectWithTag("Bombita").GetComponent<BombDmg>();
        dmgC = GameObject.FindGameObjectWithTag("damageController").GetComponent<DmgController>();
        actualvida = maxVida;
    }

    void Update()
    {
        if (actualvida <= 0)
        {
            Dead();
        }
    }

    public void GainLife(float life) => actualvida += life;

    public void LoseLife(float dmg) => actualvida -= dmg;

    public void Dead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("AtkBomb"))
        {
            actualvida -= 0.25f * dmgC.dmgMultiplier;
        }

    }
}
