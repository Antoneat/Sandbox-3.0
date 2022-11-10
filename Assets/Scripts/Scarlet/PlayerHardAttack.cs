using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHardAttack : MonoBehaviour
{
    public bool isHardAttacking;

    //public bool continueHardAttack;
    //public bool nextHardAttack;

    public float rotationSpeed;
    private Quaternion rotateTo;
    private Vector3 direction;

    [Header("Components")]
    public Animator anim;
    public GameObject guadanaParticles;
    public GameObject ataqueHardCollider;
    private PlayerMovement playerMovement;
    private PlayerDash playerDash;
    private PlayerAttackCombo playerAttackCombo;
    [SerializeField] private GameObject mousePos;

    void Start()
    {
        isHardAttacking = false;
        //continueHardAttack = false;
        //nextHardAttack = false;

        anim = GetComponent<Animator>();

        playerMovement = GetComponent<PlayerMovement>();
        playerDash = GetComponent<PlayerDash>();
        playerAttackCombo = GetComponent<PlayerAttackCombo>();
    }

    void Update()
    {
        HardCombo();
        mousePos = GameObject.FindGameObjectWithTag("MousePos");

        if(isHardAttacking == true && Input.GetMouseButtonDown(1))
        {
            //nextHardAttack = true;
            direction = (mousePos.transform.position - transform.position).normalized;
        }

        // if(nextHardAttack == true)
        // {
        //     anim.SetBool("ContinueHardCombo", true);
        //     continueHardAttack = true;
        // }
        // else if(nextHardAttack == false)
        // {
        //     anim.SetBool("ContinueHardCombo",false);
        //     continueHardAttack = false;
        // }

        // if(nextHardAttack == false && playerDash.isDashing == false && isHardAttacking == false)
        // {
        //     playerMovement.maxSpeed = 7.2f;
        // }
    }

    public void HardCombo()
    {
        if (Input.GetMouseButtonDown(1) && isHardAttacking == false && playerAttackCombo.isAttacking == false && playerDash.isDashing == false)
        {
            direction = (mousePos.transform.position - transform.position).normalized;

            playerMovement.lastTransform = new Vector3(mousePos.transform.position.x, 0, mousePos.transform.position.z);

            anim.SetTrigger("AtaqueFuerte");
        }

        //MOVE
        //Vector3.MoveTowards(transform.position, mousePos.transform.position, 2f * Time.deltaTime);

        if (isHardAttacking)
        {
            //PARTICLES
            guadanaParticles.SetActive(true);
            
            //ROTATION
            rotateTo = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotateTo, rotationSpeed * Time.deltaTime);
        }
    }

    public void StopMovementHard()
    {
        playerMovement.maxSpeed = 3f;
        isHardAttacking = true;
    }

    public void HardAttacking()
    {
        isHardAttacking = true;
        //continueHardAttack = false;
    }

    public void AfterHardAttacking()
    {
        //nextHardAttack = false;
        anim.ResetTrigger("AtaqueFuerte");
    }

    public void FinalHardAttack()
    {
        //nextHardAttack = false;
        playerMovement.maxSpeed = 7.2f;
        isHardAttacking = false;
        //continueHardAttack = false;
    }

    #region Ataques Fuertes 1, (2 y 3)
    public void HardAttack1Active()
    {
        ataqueHardCollider.SetActive(true);
    }

    // public void HardAttack2Active()
    // {
    //     ataqueHardCollider.SetActive(true);
    // }

    // public void HardAttack3Active()
    // {
    //     ataqueHardCollider.SetActive(true);
    // }

    public void DeactivatingCollsHardAttack()
    {
        ataqueHardCollider.SetActive(false);
    }

    #endregion
}
