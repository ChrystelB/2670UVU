using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDamage : MonoBehaviour {

	public GameObject damage100meter;
	public GameObject damage200meter;
	public GameObject damage300meter;

	private Image damage100img;
	private Image damage200img;
	private Image damage300img;

	public Text damagePercent;
	private int damage;
	public GameObject player;
	private Animator playerAnim;

	public void StartGame()
	{
		damage100img = damage100meter.GetComponent<Image>();
		damage200img = damage200meter.GetComponent<Image>();
		damage300img = damage300meter.GetComponent<Image>();

		playerAnim = player.GetComponent<Animator>();
	}

	//updates damage meter display
	public void DisplayMeter()
	{
		damage = playerAnim.GetInteger("damage");

		//converts damage into an int that the switch statement can use
		int temp_damage;
		//(damage - 1) is used instead of the true value of damage to simulate <= 100.
		temp_damage = (damage - 1) / 100;

		//converts damage to a float to be used in calculating image fill amount
		float float_damage;
		float_damage = damage;

		//decides which meter to fill based on temp_damage
		switch(temp_damage)
		{
			//if damage <= 100
			case 0:

				print("increasing fill of green meter");
				print(damage / 100);
				damage100img.fillAmount = (float_damage / 100);

				break;

			//if 100 < damage <= 200
			case 1:

				print("increasing fill of yellow meter");
				damage100img.fillAmount = (float_damage / 100);
				damage200img.fillAmount = ((float_damage / 100) - 1);

				break;

			//if 200 < damage < 300
			case 2:

				print("increasing fill of red meter");
				damage100img.fillAmount = (float_damage / 100);
				damage200img.fillAmount = ((float_damage / 100) - 1);
				damage300img.fillAmount = ((float_damage / 100) - 2);

				break;

			//if damage = 300		
			case 3:

				print("maximum damage");
				damage300img.fillAmount = (float_damage / 100);

				break;
		}
	}

	//updates damage percentage display
	public void DisplayPercent()
	{
        damage = playerAnim.GetInteger("damage");

		damagePercent.text = damage + "%";
	}
}
