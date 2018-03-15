using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalAnimsCtrl : MonoBehaviour {

	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void Idle()
	{
		animator.SetBool("beingCarried", false);
	}

	public void BeingCarried()
	{
		animator.SetBool("beingCarried", true);
	}

}
