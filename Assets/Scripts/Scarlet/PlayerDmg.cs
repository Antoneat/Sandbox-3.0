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

    [Header("Animator")]
    [SerializeField] private Animator anim;

    void Start()
    {
        //dmgC = GameObject.FindGameObjectWithTag("damageController").GetComponent<DmgController>();
        actualvida = maxVida;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        consolaComandos = FindObjectOfType<ConsolaComandosManager>();

        if (actualvida <= 0)
        {
            Dead();
        }

        if (actualvida > maxVida)
        {
            actualvida = maxVida;
        }

    }

    public void GainLife(float life) => actualvida += life;

    public void LoseLife(float dmg) => actualvida -= dmg;

    public void Dead()
    {
        consolaComandos.panelReinicio.SetActive(true);
        anim.Play("Muerte");
        Destroy(gameObject, 3.20f);
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("AtkBomb"))
        {
            actualvida -= 0.25f; //* mecanica tinoco: dmgC.dmgMultiplier; andre no jodas tkm
        }

        if (collider.gameObject.CompareTag("Lanza"))
        {
            actualvida -= 2.5f;
        }
    }
}
