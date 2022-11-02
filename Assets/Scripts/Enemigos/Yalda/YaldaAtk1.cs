using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaldaAtk1 : MonoBehaviour
{

	public bool coPlay;
	public bool isAtk1;

	[Header("FeedbackVisual")]
	[SerializeField] GameObject yalda;
	Renderer yaldaRender;

	[Header("Ataque1")]
	[SerializeField] YaldaMov yam;
	public Animator anim;
	public Collider mano1collider;
	public Collider mano2collider;


	void Start()
	{
		yaldaRender = yalda.GetComponent<Renderer>();
		anim = GetComponent<Animator>();
	}


    public void Attack1()
    {
        anim.Play("atk1");
		isAtk1 = true;
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
		coPlay = true;
		yam.agent.isStopped = true;
		ChangeColorPreAtk();


		yield return new WaitForSeconds(1f);

		Attack1();
		
		yam.agent.isStopped = false;
		coPlay = false;
		yield break;
	}

	void ChangeColorPreAtk()
	{
		yaldaRender.material.color = Color.yellow;
	}
	void ChangeColorPostAtk()
	{
		yaldaRender.material.color = Color.white;
	}
}
