using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPortrait : MonoBehaviour {

	public GameObject player;

	public Image portraitImg;

	public void StartGame()
	{
		SO_Player so_Player;
		so_Player = player.GetComponent<PlayerController>().player;

		portraitImg.sprite = so_Player.charPortrait;
	}
}