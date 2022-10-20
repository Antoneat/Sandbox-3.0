using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCombo : MonoBehaviour
{
    public int combo;
    public bool isAttacking;

    [Header("Components")]
    public Animator anim;
    public GameObject ataqueBasico1Collider;
    public GameObject ataqueBasico2Collider;
    public GameObject ataqueBasico3Collider;
    private PlayerMovement playerMovement;
    private PlayerDash playerDash;
    private PlayerHardAttack playerHardAttack;
    [SerializeField] private GameObject mousePos;

    void Start()
    {
        combo = 0;
        isAttacking = false;

        anim = GetComponent<Animator>();

        playerMovement = GetComponent<PlayerMovement>();
        playerHardAttack = GetComponent<PlayerHardAttack>();
        playerDash = GetComponent<PlayerDash>();
    }

    void Update()
    {
        Combo();
        mousePos = GameObject.FindGameObjectWithTag("MousePos");
    }

    public void Combo()
    {
        if (Input.GetMouseButtonDown(0) && isAttacking == false && playerHardAttack.isHardAttacking == false && playerDash.isDashing == false)
        {
            isAttacking = true;

            playerMovement.playerTransform.LookAt(mousePos.transform.position);

            playerMovement.lastTransform = new Vector3(mousePos.transform.position.x, 0, mousePos.transform.position.z);

            Vector3.MoveTowards(transform.position, mousePos.transform.position, 1f);

            playerHardAttack.hardCombo = 0;

            anim.Play("AtaqueBasico" + combo);
        }
    }

    public void StopMovement()
    {
        playerMovement.maxSpeed = 0f;
    }

    public void Attacking() // Cambiar por un bool para cuando termine la anim, cambie al sgte
    {
        Debug.Log("Atacando");
        isAttacking = false;
        if (combo < 3) combo++;
    }
    public void AfterAttacking()
    {
        Debug.Log("Termino de atacar");
        isAttacking = false;

        playerMovement.maxSpeed = 7.2f;
        playerMovement.enabled = true;

        combo = 0;
    }

    #region Ataques 1, 2 y 3
    public void BasicAttack1Active()
    {
        ataqueBasico1Collider.SetActive(true);
        ataqueBasico2Collider.SetActive(false);
        ataqueBasico3Collider.SetActive(false);
    }
    
    public void BasicAttack2Active()
    {
        ataqueBasico1Collider.SetActive(false);
        ataqueBasico2Collider.SetActive(true);
        ataqueBasico3Collider.SetActive(false);
    }
    public void BasicAttack3Active()
    {
        ataqueBasico1Collider.SetActive(false);
        ataqueBasico2Collider.SetActive(false);
        ataqueBasico3Collider.SetActive(true);
    }
    public void BasicAttackDeactiveColl()
    {
        ataqueBasico1Collider.SetActive(false);
        ataqueBasico2Collider.SetActive(false);
        ataqueBasico3Collider.SetActive(false);
    }

    #endregion
}
