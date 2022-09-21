using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCombo : MonoBehaviour
{
    // public Animator anim;
    public BoxCollider armaCollider;

    [SerializeField] private int combo;

    //public AudioSource audio;
    // public AudioClip[] sonido;

    void Start()
    {
        // anim = GetCompenent<Animator>();
        // audio = GetComponent<AudioSouce>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            // anim.SetTrigger("PrimerAtaque" + combo);
            // audio.clip = sonido[combo];
            // audio.Play();
            armaCollider.enabled = true;
        }
    }

    public void Attacking()
    {
        Debug.Log("Atacando");
        armaCollider.enabled = true;
        if (combo < 3) combo++;
    }

    public void AfterAttacking()
    {
        Debug.Log("Termino de atacar");
        armaCollider.enabled = false;
        combo = 0;
    }
}
