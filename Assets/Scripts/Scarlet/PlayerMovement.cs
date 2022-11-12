using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float maxSpeed;

    public Vector3 lastTransform;

    [Header("Componentes")]
    public Rigidbody rgbd;
    public Transform playerTransform;
    private PlayerDash playerDash;

    [Header("Animator")]
    public Animator anim;
    public float velocityOfMovement;
    public float acceleration;
    public float deceleration;
    public float speedLimiter = 1;

    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
        playerDash = GetComponent<PlayerDash>();
    }

    void FixedUpdate()
    {
        Move();
        PlayerRotation();
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        rgbd.velocity = new Vector3(horizontal * speed * Time.fixedDeltaTime * speedLimiter, 0, vertical * speed * speedLimiter * Time.fixedDeltaTime);

        if (rgbd.velocity.magnitude > maxSpeed)
        {
            rgbd.velocity = Vector3.ClampMagnitude(rgbd.velocity, maxSpeed);
        }

        if (rgbd.velocity.magnitude != 0 && velocityOfMovement < 1.0f && playerDash.isDashing == false)
        {
            velocityOfMovement += Time.deltaTime * acceleration;
        }
        else if (rgbd.velocity.magnitude == 0 && velocityOfMovement > 0.0f)
        {
            velocityOfMovement -= Time.deltaTime * deceleration;
        }

        if (velocityOfMovement < 0.0f)
        { 
            velocityOfMovement = 0.0f;
        }

        anim.SetFloat("Run", velocityOfMovement);
    }

    public void PlayerRotation()
    {
        if (rgbd.velocity.normalized != lastTransform && rgbd.velocity != Vector3.zero)
        {
            lastTransform = rgbd.velocity.normalized;
        }

        if(rgbd.velocity != Vector3.zero)
        {
            playerTransform.rotation = Quaternion.LookRotation(new Vector3(rgbd.velocity.normalized.x, 0, rgbd.velocity.normalized.z));
        }
    }
}
