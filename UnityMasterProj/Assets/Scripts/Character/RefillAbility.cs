using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillAbility : MonoBehaviour {

	private Animator playerAnim;

	public void StartGame()
	{
		playerAnim = GetComponent<Animator>();
		print(playerAnim);
	}

	public void StartRecharge()
	{
		StartCoroutine(Recharge());
	}

	IEnumerator Recharge()
	{
		while(playerAnim.GetInteger("abilityCharge") < 100){

			int _tempAbilityCharge;
			_tempAbilityCharge = playerAnim.GetInteger("abilityCharge");
			_tempAbilityCharge++;

			playerAnim.SetInteger("abilityCharge", _tempAbilityCharge);

			yield return new WaitForSeconds(0.1f);
		}
	}
}
