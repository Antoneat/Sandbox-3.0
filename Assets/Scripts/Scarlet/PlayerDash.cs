using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Dashing")]
    public float dashNewSpeed;
    public bool canDash;
    public bool isDashing;
    public float cooldown;

    [Header("Componentes")]
    [SerializeField] private Animator anim;
    private PlayerMovement playerMovement;
    private PlayerAttackCombo playerAttackCombo;
    private PlayerHardAttack playerHardAttack;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        playerAttackCombo = GetComponent<PlayerAttackCombo>();
        playerHardAttack = GetComponent<PlayerHardAttack>();
        canDash = true;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDashing == false && canDash == true)
        {
            canDash = false;
            isDashing = true;
            anim.Play("Dash");
            ResetAttacks();
        }
    }

    public void Dashing()
    {
        Debug.Log("Dashing");
        playerMovement.maxSpeed = dashNewSpeed;
        Physics.IgnoreLayerCollision(3, 8, true);
    }

    public void FinishDash()
    {
        Debug.Log("Termino el Dash");
        Invoke(nameof(DelayToDash), cooldown);
        isDashing = false;
        playerMovement.maxSpeed = 7.2f;

        playerMovement.enabled = true;

        Physics.IgnoreLayerCollision(3, 8, false);
    }

    public void DelayToDash()
    {
        canDash = true;
    }

    #region No ver :D
    public void ResetAttacks()
    {
        playerAttackCombo.isAttacking = false;
        playerAttackCombo.continueAttack = false;
        playerAttackCombo.nextAttack = false;
        playerAttackCombo.ataqueBasico1Collider.SetActive(false);
        playerAttackCombo.ataqueBasico2Collider.SetActive(false);
        playerAttackCombo.ataqueBasico3Collider.SetActive(false);
        playerHardAttack.isHardAttacking = false;
        playerHardAttack.ataqueHardCollider.enabled = false;
    }
    #endregion
}
