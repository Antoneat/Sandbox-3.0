using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private Rigidbody rgbd;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator anim;
    public Transform orientation;

    [Header("Dashing")]
    public float dashForce;
    public float dashDuration; // reemplazado por la duracion de la anim (eliminar de la consola)
    public bool isDashing;

    [Header("ResetDash")]
    public bool killedEnemy;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            isDashing = true;
            anim.SetTrigger("Dash");
        }
    }
    
    public void Dashing()
    {
        Debug.Log("Dashing");
        playerMovement.maxSpeed = 10f;
        //Vector3 forceToApply = orientation.forward * dashForce * Time.deltaTime;
        Vector3 forceToApply = rgbd.velocity.normalized * dashForce;
        rgbd.AddForce(forceToApply, ForceMode.Impulse);
    }

    public void FinishDash()
    {
        Debug.Log("Termino el Dash");
        isDashing = false;
        playerMovement.maxSpeed = 7.2f;
        killedEnemy = false;
    }
}
