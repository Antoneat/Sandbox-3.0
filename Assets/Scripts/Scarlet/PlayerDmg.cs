using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDmg : MonoBehaviour
{
    [Header("Vida")]
    public float actualvida;
    public float maxVida = 30f;
    //private DmgController dmgC;
    public ConsolaComandosManager consolaComandos;

    public int actualSouls;

    public PlayerMovement playerMovement;

    [Header("Animator")]
    [SerializeField] private Animator anim;

    void Start()
    {
        //dmgC = GameObject.FindGameObjectWithTag("damageController").GetComponent<DmgController>();
        actualvida = maxVida;
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        consolaComandos = FindObjectOfType<ConsolaComandosManager>();

        if (actualvida <= 0)
        {
            playerMovement.maxSpeed = 0;
            anim.Play("Morir");
            Invoke(nameof(Dead), 3.20f);
            //Destroy(gameObject, 3.20f);
            
        }

        if (actualvida > maxVida)
        {
            actualvida = maxVida;
        }
    }

    public void GainLife(float life) => actualvida += life;

    public void GainSoul(int soul) => actualSouls += soul;

    public void LoseLife(float dmg) => actualvida -= dmg;

    public void Dead()
    {
        consolaComandos.panelReinicio.SetActive(true);
    }
}
