using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCombo : MonoBehaviour
{
    public Animator anim;
    public BoxCollider armaCollider;
    public PlayerHardAttack playerHardAttack;

    public int combo;
    public bool attacking;

    // public AudioSource audioSourse;
    // public AudioClip[] sonido;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerHardAttack = GetComponent<PlayerHardAttack>();
        // audioSourse = GetComponent<AudioSouce>();
    }

    void Update()
    {
        Combo();
    }

    public void Combo()
    {
        if (Input.GetKeyDown(KeyCode.J) && !attacking && !playerHardAttack.hardAttacking)
        {
            attacking = true;
            playerHardAttack.hardCombo = 0;
            anim.SetTrigger("Ataque" + combo);
            // audio.clip = sonido[combo];
            // audio.Play();
            // armaCollider.enabled = true;
        }
    }

    public void Attacking()
    {
        Debug.Log("Atacando");
        attacking = false;
        // armaCollider.enabled = true;
        if (combo < 3) combo++;
    }

    public void AfterAttacking()
    {
        Debug.Log("Termino de atacar");
        attacking = false;
        // armaCollider.enabled = false;
        combo = 0;
    }
}
