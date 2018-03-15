using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAbility : MonoBehaviour {

	public GameObject player;
	private Animator playerAnim;

	public Image abilityImg;

	public void StartGame()
	{
		playerAnim = player.GetComponent<Animator>();
	}

	public void StartFillGauge()
	{
		StartCoroutine(FillGauge());
	}

	IEnumerator FillGauge()
	{
		while(playerAnim.GetInteger("abilityCharge") < 100)
		{
			float _tempAbilityCharge;
			_tempAbilityCharge = playerAnim.GetInteger("abilityCharge");
			_tempAbilityCharge /= 100;

			abilityImg.fillAmount = _tempAbilityCharge;

			yield return null;
		}
	}

}
