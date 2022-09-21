using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsPatrol : MonoBehaviour
{

	public Transform player;

	public Transform teleport;
	public Transform teleport2;
	public Transform teleport3;
	public Transform teleport4;


	//public float damping = 6.0f;


	//public Transform[] goals;
	public UnityEngine.AI.NavMeshAgent agent;

	public Transform goal1;
	public Transform goal2;
	public Transform goal3;
	public Transform goal4;

	public Hands h;

	public Player plyr;

	void Start()
	{
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		

		//agent.autoBraking = false;
	}

	void Update()
	{
		

	}




	public void GotoNextPoint1()
	{
		agent.destination = goal1.position;

	}

	public void GotoNextPoint2()
	{

		agent.destination = goal2.position;
	}

	public void GotoNextPoint3()
	{
		agent.destination = goal3.position;

	}
	public void GotoNextPoint4()
	{

		agent.destination = goal4.position;
	}

	private void OnTriggerEnter(Collider collider)
	{


		if (collider.gameObject.CompareTag("portalA"))
		agent.Warp(teleport.position);

		if (collider.gameObject.CompareTag("PortalB"))
		agent.Warp(teleport2.position);

		if (collider.gameObject.CompareTag("PortalC"))
		agent.Warp(teleport3.position);

		if (collider.gameObject.CompareTag("PortalD"))
		agent.Warp(teleport4.position);

		if (h.vulnerable == true)
		{
			if (collider.gameObject.CompareTag("AtaqueUno")) h.actualvida -= plyr.AttackDmgUno; // Baja la vida del enemigo acorde con el valor que se puso en el ataque.

			if (collider.gameObject.CompareTag("AtaqueDos")) h.actualvida -= plyr.AttackDmgDos; // Lo de arriba x2.

			if (collider.gameObject.CompareTag("AtaqueTres")) h.actualvida -= plyr.AttackDmgTres; // Lo de arriba x3.

			if (collider.gameObject.CompareTag("AtaqueCargado")) h.actualvida -= plyr.AttackDmgCargado; // Lo de arriba x4.
		}
	}

}