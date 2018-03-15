using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayElementCharge : MonoBehaviour {

	public GameObject player;
	private Animator playerAnim;

	public Image elementChargeImg;

	public void StartGame()
	{
		playerAnim = player.GetComponent<Animator>();
	}

	public void StartDepleteGauge()
	{
		StartCoroutine(DepleteGauge());
	}

	IEnumerator DepleteGauge()
	{

		while(playerAnim.GetInteger("elementCharge") > 0)
		{
			float _tempElementCharge;
			_tempElementCharge = playerAnim.GetInteger("elementCharge");
			_tempElementCharge /= 100;

			elementChargeImg.fillAmount = _tempElementCharge;

			yield return null;
		}
	}

}
