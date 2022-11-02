using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaldaMov : MonoBehaviour
{
	public UnityEngine.AI.NavMeshAgent agent;

	public int destPoint = 0;
	public Transform goal;

	public float playerDistance;
	public float awareAI;
	public float atkRange;


	[Header("Ataque1")]
	[SerializeField] YaldaAtk1 ya1;


	void Start()
	{
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

		goal = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		agent.SetDestination(goal.position);



		ya1.coPlay = false;
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


		if (playerDistance <= atkRange && ya1.coPlay == false)
		{
			StartCoroutine(ya1.AtaqueBasico());
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
		ya1.isAtk1 = false;
	}

}
