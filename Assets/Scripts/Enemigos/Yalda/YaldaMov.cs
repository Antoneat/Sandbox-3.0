using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YaldaMov : MonoBehaviour
{
	public NavMeshAgent agent;

	public int destPoint = 0;
	public Transform goal;

	public float playerDistance;
	public float awareAI; //RANGO DE DETECCION
	public float atkRange; //RANGO DE ATAQUE


	[Header("Ataque1")]
	[SerializeField] YaldaAtk1 yaldaAtk1;


	void Start()
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent>();

		goal = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		agent.SetDestination(goal.position);

		yaldaAtk1.corrutinePlay = false;
	}

	void Update()
	{
		playerDistance = Vector3.Distance(transform.position, goal.position);

		if (playerDistance <= awareAI)
		{
			LookAtPlayer();
			Debug.Log("Seen");
			Chase();
			//agent.isStopped = false;
		}
		else if (playerDistance > awareAI)
		{
			LookAtPlayer();
			agent.isStopped = true;
		}

		if (playerDistance <= atkRange && yaldaAtk1.corrutinePlay == false)
		{
			StartCoroutine(yaldaAtk1.AtaqueBasico());
			//agent.isStopped = false;
		}
		else if (playerDistance > atkRange)
		{
			LookAtPlayer();
			//agent.isStopped = false;
		}
	}

	void LookAtPlayer()
	{
		transform.LookAt(goal);
	}

	public void Chase()
	{
		agent.SetDestination(goal.position);
		yaldaAtk1.isAtk1 = false;
	}
}
