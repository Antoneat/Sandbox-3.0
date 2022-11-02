using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaldaAtk1 : MonoBehaviour
{
	public bool corrutinePlay;
	public bool isAtk1;

	[Header("FeedbackVisual")]
	[SerializeField] GameObject yalda;
	Renderer yaldaRender;

	[Header("Ataque1")]
	[SerializeField] YaldaMov yaldaMov;
	public Animator anim;
	public Collider mano1collider, mano2collider;

	void Start()
	{
		yaldaRender = yalda.GetComponent<Renderer>();
		anim = GetComponent<Animator>();
	}

	public void Attack1Collider()
	{
		if(isAtk1)
        {
			mano1collider.enabled = true;
			mano2collider.enabled = true;
		}
		else
        {
			mano1collider.enabled = false;
			mano2collider.enabled = false;
		}
	}


	public IEnumerator AtaqueBasico()
	{
		corrutinePlay = true;
		yaldaMov.agent.isStopped = true;
		ChangeColorPreAtk();


		yield return new WaitForSeconds(1f);

		Attack1();

		ChangeColorDuringAtk();
		
		yaldaMov.agent.isStopped = false;
		corrutinePlay = false;
		yield break;
	}

    public void Attack1()
    {
        anim.Play("atk1");
		isAtk1 = true;
    }

	void ChangeColorPreAtk()
	{
		yaldaRender.material.color = Color.yellow;
	}

	void ChangeColorDuringAtk()
	{
		yaldaRender.material.color = Color.red;
	}
}
