using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepleteElement : MonoBehaviour {

	private Animator playerAnim;

	public void StartGame()
	{
		playerAnim = GetComponent<Animator>();
		print(playerAnim);
	}

	public void StartDeplete()
	{
		StartCoroutine(Deplete());
	}

	IEnumerator Deplete()
	{
		while(playerAnim.GetInteger("elementCharge") > 0){

			int _tempElementCharge;
			_tempElementCharge = playerAnim.GetInteger("elementCharge");
			_tempElementCharge--;

			playerAnim.SetInteger("elementCharge", _tempElementCharge);

			yield return new WaitForSeconds(0.1f);
		}
	}
}