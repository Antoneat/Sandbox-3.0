using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgController : MonoBehaviour
{
    private PlayerDmg plyrDMG;
    private PlayerDash plyrDash;

    private BombDmg bombdmg;
    public GameObject[] Bombitas;
    public bool deadBomb;

    private BuscadorController dogC;
    private BuscadorDmg dogdmg;
    public bool deadBusc;

    public float dmgMultiplier;

    void Start()
    {
        plyrDMG = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDmg>();
        plyrDash = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDash>();


        bombdmg = GameObject.FindGameObjectWithTag("Bombita").GetComponent<BombDmg>();
        dogC = GameObject.FindGameObjectWithTag("Buscador").GetComponent<BuscadorController>();
        dogdmg = GameObject.FindGameObjectWithTag("Buscador").GetComponent<BuscadorDmg>();

        Bombitas = new GameObject[5];
    }


    void Update()
    {
        Bombitas = GameObject.FindGameObjectsWithTag("Bombita");
     
        BombDA�O();

    }

    public void BombDA�O()
    {
        foreach (GameObject Bombita in Bombitas)
        {
            dmgMultiplier += 1;
            if (dmgMultiplier >= 5f)
            {
                dmgMultiplier = 0;
            }
        }
    }


    public void BuscadorDA�O()
    {
        if (dogC.ataco == true)
        {

            plyrDMG.actualvida -= 1.75f;

        }
    }

  

  

}
