using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHardAttack : MonoBehaviour
{
    public int hardCombo;
    public bool isHardAttacking;

    [Header("Components")]
    public Animator anim;
    public Collider ataqueHardCollider;
    private PlayerMovement playerMovement;
    private PlayerDash playerDash;
    private PlayerAttackCombo playerAttackCombo;
    [SerializeField] private GameObject mousePos;

    void Start()
    {
        hardCombo = 0;
        isHardAttacking = false;

        anim = GetComponent<Animator>();

        playerAttackCombo = GetComponent<PlayerAttackCombo>();
        playerMovement = GetComponent<PlayerMovement>();
        playerDash = GetComponent<PlayerDash>();
    }

    void Update()
    {
        //HardCombo();
        mousePos = GameObject.FindGameObjectWithTag("MousePos");
    }

    public void HardCombo()
    {
        if (Input.GetMouseButtonDown(1) && isHardAttacking == false && playerAttackCombo.isAttacking == false && playerDash.isDashing == false)
        {
            isHardAttacking = true;

            playerMovement.playerTransform.LookAt(mousePos.transform.position);
            playerMovement.lastTransform = new Vector3(mousePos.transform.position.x, 0, mousePos.transform.position.z);

            Vector3.MoveTowards(transform.position, mousePos.transform.position, 1f);

            playerAttackCombo.combo = 0;

            anim.Play("AtaqueFuerte" + hardCombo);
        }
    }

    public void StopMovement()
    {
        playerMovement.maxSpeed = 0f;
    }

    public void HardAttacking()
    {
        Debug.Log("AtacandoHARD");
        isHardAttacking = false;
        if (hardCombo < 3) hardCombo++;
    }

    public void ActivatingCollsHardAttack()
    {
        ataqueHardCollider.enabled = true;
    }

    public void DeactivatingCollsHardAttack()
    {
        ataqueHardCollider.enabled = false;
    }

    public void AfterHardAttacking()
    {
        Debug.Log("Termino de atacarHARD");
        isHardAttacking = false;
        ataqueHardCollider.enabled = false;

        playerMovement.maxSpeed = 7.2f;
        playerMovement.enabled = true;

        hardCombo = 0;
    }
}
