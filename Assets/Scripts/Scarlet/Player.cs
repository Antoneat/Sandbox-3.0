using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed;
    public float maxSpeed;
    public Vector3 movement;
    public Transform playerTransform;
    public Rigidbody rb;
    public SpriteRenderer spriteRenderer; //Giro del sprite
    public LayerMask suelo;

    [Header("Vida")]
    public float actualvida;
    private float maxVida = 30;
    //public LifeBar lifeBar;

    [Header("Desplazamiento")]
    public bool dash;
    public float speedDash;
    public float dashCooldown;
    public float dashCoolCounter;
    public bool killedEnemy;
    public GameObject dashIMG;

    [Header("AtaqueCombo")]
    public int numberOfClicks = 0;
    private float lastClickedTime = 0;
    private float maxComboDelay = 0.8f;
    public int AttackDmgUno = 10;
    public int AttackDmgDos = 20;
    public int AttackDmgTres = 30;
    public GameObject ataqueUnoGO;
    public GameObject ataqueDosGO;
    public GameObject ataqueTresGO;
    public bool attackCombo = false;
    public float attackCooldown = 0.25f;
    private float timePressed = 0.9f;

    [Header("AtaqueCargado")]
    //[SerializeField] private float radio = 5f;
    public GameObject ataqueCargGO;
    public int AttackDmgCargado = 5;
    public bool attackCharged = false;
    public GameObject attackChargIMG;

    [Header("Bloqueo")]
    public float bloqueoDuracion;
    public float bloqueoMaxDuracion;
    public bool blck;
    public int cargasDeExplosion;
    public float bloqueoCooldown;
    public float bloqueoCounter;
    public LayerMask enemyLayer;
    public GameObject bloqueoIMG;

    [Header("Almas")]
    public float almas;
    public TMP_Text almasText;

    [Header("Extra")]
    //[SerializeField] private Enemy enmy;
    //[SerializeField] private Enemy2 enmy2;
    //[SerializeField] private Yaldabaoth yp;
    [SerializeField] private int sceneId = 1;
    int a = 0;
    int b = 0;
   // public StateManager SM;
    public bool closeToStair;
    public bool dashMejorado;
    public bool basicoMejorado;
    public bool cargadoRojo;
    public bool cargadoAzul;

    [Header("VFX")]
    public GameObject ataqueUno;
    public GameObject ataqueDos;
    public GameObject ataqueTres;

    [Header("Coleccionables")]
    public int collectables = 1;
    public int counterCollectables = 0;
    public TMP_Text collecTxt;
    public GameObject collecTxtGO;
    public float counterNum;

    [Header("Enemigos")]
    [SerializeField] private GameObject BuscadorPrefab;
    [SerializeField] private GameObject VerdugoPrefab;
    [SerializeField] private GameObject YaldaPrefab;
    public int enemigosDerrotados;
    //[SerializeField] private GameObject SamaelPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemigosDerrotados = 0;
        actualvida = maxVida;
        //lifeBar.SetMaxVida(maxVida);
        //almas = 0;
        blck = false;
        bloqueoDuracion = bloqueoMaxDuracion;

        closeToStair = false;

        collecTxtGO.SetActive(false);

        //Console.instance.RegisterCommand("godmode", godmode, "Activar/Desactivar el modo Dios.");
        //Console.instance.RegisterCommand("restartlevel", resetlevel, "Reiniciar nivel");
        //Console.instance.RegisterCommand("previouslevel", previouslevel, "Nivel anterior");
        //Console.instance.RegisterCommand("nextlevel", nextlevel, "Siguiente nivel");
        //Console.instance.RegisterCommand("crt", crt, "Creditos");
        //Console.instance.RegisterCommand("infinitedmg", infinitedmg, "Da�o infinito");
    }

    void Update()
    {
        if (actualvida>maxVida)
        {
            actualvida = maxVida;
            //lifeBar.SetVida(actualvida);
        }
        invocacionesEnemigos();
        Blocking();

        Caida();

        //collecTxt.text = counterCollectables.ToString() + " / 5";

        counterNum += Time.deltaTime;

        if (collectables == counterCollectables)
        {
            Collects();
            counterNum = 0;
        }
        if (counterNum > 3)
        {
            collecTxtGO.SetActive(false);
            counterNum = 0;
        }

        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0f || killedEnemy == true)
            {
                dash = true;
                dashCoolCounter = dashCooldown;
                dashIMG.SetActive(false);
                StartCoroutine(Dash());
            }
        }
        if (dashMejorado)
        {
            if (dashCoolCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
            }
            if (dashCoolCounter >= 0)
            {
                dash = false;
            }
            if (dashCoolCounter < 0)
            {
                dashIMG.SetActive(true);
            }
        }
        else if(!dashMejorado)
        {
            dash = false;
        }

        if (bloqueoDuracion > 0 && Input.GetKey(KeyCode.K))
        {
            bloqueoDuracion -= Time.deltaTime;
        }

        if (bloqueoCounter <= bloqueoCooldown && blck == false)
        {
            bloqueoCounter -= Time.deltaTime;
        }   

        attackCooldown -= Time.deltaTime;

        if (Input.GetKey(KeyCode.J))
        {
            timePressed -= Time.deltaTime;
        }
        if (timePressed >= 0 && Input.GetKeyUp(KeyCode.J))
        {
            attackCombo = true;
            attackCharged = false;
        }
        if (timePressed < 0 && Input.GetKeyUp(KeyCode.J))
        {
            attackCombo = false;
            attackCharged = true;
        }

        if (Time.time - lastClickedTime > maxComboDelay)
        {
            numberOfClicks = 0;
            ataqueUnoGO.SetActive(false);
            ataqueDosGO.SetActive(false);
            ataqueTresGO.SetActive(false);
            ataqueUno.SetActive(false);
            ataqueDos.SetActive(false);
            ataqueTres.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Movimiento();
        
        if (attackCombo)
        {
            AttackCombo();
            timePressed = 1f;
        }

        if (attackCharged)
        {
            StartCoroutine(AttackingCharg());
            timePressed = 1f;
            speed = 0;
        }
        
        if (closeToStair)
        {
            if (rb.velocity.y < 0)
            {
                rb.AddForce(Vector3.down * 6f, ForceMode.Impulse);
            }
            if(rb.velocity.y >= 0)
            {
                speed = 800;
            }
        }
    }

    public void Movimiento()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (dash == false) 
        {
            rb.velocity = new Vector3(horizontal * speed * Time.fixedDeltaTime, rb.velocity.y, vertical * speed * Time.fixedDeltaTime);
            playerTransform.rotation = Quaternion.LookRotation(movement);
            //movement = new Vector3(0, 0, 0);
        }

        if (horizontal > 0 && !attackCharged) //Direcci�n donde se mueve
        {
            speed = 400;
            movement.z = 0;
            movement.x = 1;
        }
        else if (horizontal < 0 && !attackCharged)
        {
            speed = 400;
            movement.z = 0;
            movement.x = -1;
        }

        if(vertical > 0 && !attackCharged)
        {
            speed = 400;
            movement.x = 0;
            movement.z = 1;
        }
        else if (vertical < 0 && !attackCharged)
        {
            speed = 400;
            movement.x = 0;
            movement.z = -1;
        }

        if(horizontal > 0 && vertical > 0 && !attackCharged)
        {
            speed = 283;
            movement.x = 1;
            movement.z = 1;
        }
        else if (horizontal < 0 && vertical < 0 && !attackCharged)
        {
            speed = 283;
            movement.x = -1;
            movement.z = -1;
        }
        else if (horizontal > 0 && vertical < 0 && !attackCharged)
        {
            speed = 283;
            movement.x = 1;
            movement.z = -1;
        }
        else if (horizontal < 0 && vertical > 0 && !attackCharged)
        {
            speed = 283;
            movement.x = -1;
            movement.z = 1;
        }

        if (rb.velocity.x < 0) //Giro del sprite cuando mueve DERECHA o IZQUIERDA 
        {
            spriteRenderer.flipX = false;
        }
        else if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Caida()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.up, out hit, 1f))
        {
            if (hit.collider.gameObject.name == "Suelo")
            {
                Debug.Log("Tocando suelo");
            }

            if (hit.collider.gameObject.name != "Suelo")
            {
                rb.AddForce(Vector3.down * 3f, ForceMode.Impulse);
                //rb.velocity.y = multiplicar su velocidad en Y;
                Debug.Log("cayendo");
            }
            Debug.DrawRay(transform.position, -transform.up * 1f, Color.red);
        }
    }
    
    IEnumerator Dash()
    {
        if(movement.z > 0)
        {
            rb.AddForce(Vector3.forward * speedDash, ForceMode.Impulse);
        }
        else if (movement.z < 0)
        {
            rb.AddForce(Vector3.back * speedDash, ForceMode.Impulse);
        }
        else if (movement.x > 0)
        {
            rb.AddForce(Vector3.right * speedDash, ForceMode.Impulse);
        }
        else if (movement.x < 0)
        {
            rb.AddForce(Vector3.left * speedDash, ForceMode.Impulse);
        }
        
        if (movement.z > 0 && movement.x > 0)
        {
            rb.AddForce(new Vector3(1, 0, 1) * speedDash, ForceMode.Impulse);
        }
        else if (movement.z > 0 && movement.x < 0)
        {
            rb.AddForce(new Vector3(-1, 0, 1) * speedDash, ForceMode.Impulse);
        }
        else if (movement.z < 0 && movement.x > 0)
        {
            rb.AddForce(new Vector3(1, 0, -1) * speedDash, ForceMode.Impulse);
        }
        else if (movement.z < 0 && movement.x < 0)
        {
            rb.AddForce(new Vector3(-1, 0, -1) * speedDash, ForceMode.Impulse);
        }

        killedEnemy = false;
        yield return new WaitForSecondsRealtime(0.3f);
        movement = new Vector3(0, 0, 0);
        yield break;
    }
    
    private void AttackCombo()
    {
        lastClickedTime = Time.time;
        numberOfClicks++;

        if (numberOfClicks == 1 && attackCooldown <=0)
        {
            ataqueUnoGO.SetActive(true);
            ataqueDosGO.SetActive(false);
            ataqueTresGO.SetActive(false);
            ataqueUno.SetActive(true);
            ataqueDos.SetActive(false);
            ataqueTres.SetActive(false);
            attackCooldown = 0.25f;
            StartCoroutine(Slowness());
        }

        numberOfClicks = Mathf.Clamp(numberOfClicks, 0, 3);

        if (numberOfClicks == 2 && attackCooldown <= 0)
        {
            ataqueUnoGO.SetActive(false);
            ataqueDosGO.SetActive(true);
            ataqueTresGO.SetActive(false);
            ataqueUno.SetActive(false);
            ataqueDos.SetActive(true);
            ataqueTres.SetActive(false);
            attackCooldown = 0.25f;
            StartCoroutine(Slowness());
        }

        if (numberOfClicks == 3 && attackCooldown <= 0)
        {
            ataqueUnoGO.SetActive(false);
            ataqueDosGO.SetActive(false);
            ataqueTresGO.SetActive(true);
            ataqueUno.SetActive(false);
            ataqueDos.SetActive(false);
            ataqueTres.SetActive(true);
            attackCooldown = 0.25f;
            StartCoroutine(Slowness());
            StartCoroutine(RestartCombo());
        }
        attackCombo = false;
    }

    IEnumerator Slowness()
    {
        speed = 70;
        yield return new WaitForSeconds(0.4f);
        speed = 400;
        yield break;
    }

    IEnumerator RestartCombo()
    {
        yield return new WaitForSeconds(1f);
        numberOfClicks = 0;
        yield break;
    }

    IEnumerator AttackingCharg()
    {
        attackChargIMG.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            ataqueCargGO.SetActive(true);
            yield return new WaitForSecondsRealtime(0.5f);
            ataqueCargGO.SetActive(false);
        }
        attackCharged = false;
        speed = 400;
        attackChargIMG.SetActive(true);
        yield break;
    }

    private void Blocking()
    {
        if (Input.GetKey(KeyCode.K) && bloqueoCounter <= 0)
        {
            blck = true;
            speed = 0;
            bloqueoIMG.SetActive(false);
            Debug.Log("Bloqueando1");
            //animacion de bloqueo
        }
        if (bloqueoDuracion <= 0 || Input.GetKeyUp(KeyCode.K) || cargasDeExplosion == 5)
        {
            blck = false;
            Debug.Log("Suelte de tecla2");
            // animacion de explosion
            StartCoroutine(DevolverDmg());
            bloqueoCounter = bloqueoCooldown;
            speed = 400;
            bloqueoIMG.SetActive(true);
        }
    }

    IEnumerator DevolverDmg()
    {
        Collider[] EnemiesInRange = Physics.OverlapSphere(transform.position, 4f, enemyLayer);
        foreach (Collider enemyInRange in EnemiesInRange)
        {
            //enemyInRange.GetComponent<Enemy>().vida -= cargasDeExplosion * 0.15f;
            //enemyInRange.GetComponent<Enemy2>().vida -= cargasDeExplosion * 0.15f;
            Debug.Log("Devolviendo dmg a enemigos3");
        }
        bloqueoDuracion = bloqueoMaxDuracion;
        cargasDeExplosion = 0;
        yield break;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 3f);
        Gizmos.color = Color.red;
    }

    private void Collects()
    {
        collecTxtGO.SetActive(true);
        collectables++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FueraDelMundo")) transform.position = new Vector3(0,0.7f,0);

    }

    private void OnTriggerEnter(Collider collider)
    {
        // if (collider.gameObject.CompareTag("RangoAtaqueEnemy1")) enmy.playerOnRange = true;
        

        if (collider.gameObject.CompareTag("manos"))
        {

            actualvida -= 4;
            //lifeBar.SetVida(actualvida);

        }

        if (collider.gameObject.CompareTag("AtaqueNormalEnemy1"))
        {
            if (blck == true)
            {
                //RecieveDmgWhenBlock(enmy.ataqueNormalDMG);
                cargasDeExplosion++;
                Debug.Log("Recibiendo dmg reducido");
            }
            else
            {
                //actualvida -= enmy.ataqueNormalDMG;
                //lifeBar.SetVida(actualvida);
            }
        }

        if (collider.gameObject.CompareTag("MordiscoEnemy1")) 
        {
            if (blck == true)
            {
                //RecieveDmgWhenBlock(enmy.mordiscoDMG);
                cargasDeExplosion++;
             //   SM.ps = PlayerState.Sangrado;
                Debug.Log("Recibiendo dmg reducido");
            }
            else
            {
               // SM.ps = PlayerState.Sangrado;
                //actualvida -= enmy.mordiscoDMG;
                //lifeBar.SetVida(actualvida);
            }
        } 

        if (collider.gameObject.CompareTag("AtkBasicoE2"))
        {
            if (blck == true)
            {
                //RecieveDmgWhenBlock(enmy2.atkbasDMG);
                cargasDeExplosion++;
                Debug.Log("Recibiendo dmg reducido");
            }
            else
            {
                //actualvida -= enmy2.atkbasDMG;
                //lifeBar.SetVida(actualvida);
            }
        }

        if (collider.gameObject.CompareTag("Golpe2"))
        {
            if (blck == true)
            {
                //RecieveDmgWhenBlock(enmy2.golpeDMG);
                cargasDeExplosion++;
                //SM.ps = PlayerState.Quemado;
                Debug.Log("Recibiendo dmg reducido");
            }
            else
            {
                //SM.ps = PlayerState.Quemado;
                //actualvida -= enmy2.golpeDMG;
                //lifeBar.SetVida(actualvida);
            }
        }

        if (collider.gameObject.CompareTag("Rafaga2"))
        {
            if (blck == true)
            {
                //RecieveDmgWhenBlock(enmy2.rafagaDMG);
                cargasDeExplosion++;
                //SM.ps = PlayerState.Quemado;
                Debug.Log("Recibiendo dmg reducido");
            }
            else
            {
                //SM.ps = PlayerState.Quemado;
                //actualvida -= enmy2.rafagaDMG;
                //lifeBar.SetVida(actualvida);
            }
        }

        if (collider.gameObject.CompareTag("onda"))
        {
            actualvida -= 6;
            //lifeBar.SetVida(actualvida);
        }

        if (collider.gameObject.CompareTag("especial"))
        {
           // actualvida -= yp.especialDMG;
            //lifeBar.SetVida(actualvida);
        }

        if (collider.gameObject.CompareTag("Escalera"))
        {
            closeToStair = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Escalera"))
        {
            closeToStair = false;
            speed = 400;
        }
    }

    /* private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("RangoAtaqueEnemy1")) enmy.playerOnRange = false;
    }
    */

    public void godmode()
    {
        a++;
        if (a % 2 == 0)
        {
            actualvida = maxVida;
        }
        else if (a % 2 == 1)
        {
            actualvida = 999999;
        }
    }

    public void infinitedmg()
    {
        b++;
        if (b % 2 == 0)
        {
            AttackDmgUno = 10;
            AttackDmgDos = 20;
            AttackDmgTres = 30;
            AttackDmgCargado = 5;
        }
        else if (b % 2 == 1)
        {
            AttackDmgUno = 999;
            AttackDmgDos = 999;
            AttackDmgTres = 999;
            AttackDmgCargado = 999;
        }
    }

    public void resetlevel()
    {
        SceneManager.LoadScene(sceneId);
        // Cuando pase de nivel agregarle en el trigger un +1 al sceneId para el reset de lvl en la consola
    }
    public void nextlevel()
    {
        SceneManager.LoadScene(sceneId + 1);
    }
    public void previouslevel()
    {
        SceneManager.LoadScene(sceneId - 1);
    }
    public void crt()
    {
        SceneManager.LoadScene(2);
    }

    public void invocacionesEnemigos()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(BuscadorPrefab, transform.position + new Vector3(2, 0, 0), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(VerdugoPrefab, transform.position + new Vector3(2,0,0), Quaternion.identity);
        }
    }

    public void RecieveDmgWhenBlock(float dmg)
    {
        actualvida -= dmg * 0.25f;
        actualvida = Mathf.Max(0, actualvida);
        //lifeBar.SetVida(actualvida);
    }
}