﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class controls where the camera looks based off of mouse movement
public class PlayerLook : MonoBehaviour 
{

	public Transform playerBody;
	public float mouseSensitivity;

	float xAxisClamp = 0.0f;

	public GameObject gameStateManager;
	private Animator gameStateMachine;

	void Start()
	{
		gameStateMachine = gameStateManager.GetComponent<Animator>();
	}

	//runs when GameStateManager changes to InGame state
	void StartGame()
	{
		StartCoroutine(Look());
	}


	IEnumerator Look()
	{
		while(gameStateMachine.GetBool("canMove")){
			if (Time.timeScale == 1) 
			{
				float xRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
				float yRotation = Input.GetAxis("Mouse Y") * mouseSensitivity;

				xAxisClamp -= yRotation;

				//there has to be two rotations in order to prevent the character's body from tilting
				Vector3 cameraRotation = transform.rotation.eulerAngles;
				Vector3 playerRotation = playerBody.rotation.eulerAngles;

				cameraRotation.x -= yRotation;
				cameraRotation.z = 0;
				playerRotation.y += xRotation;

				//prevents the weird jerking caused by the mouse being too far up or down
				if(xAxisClamp > 90) 
				{
					xAxisClamp = 90;
					cameraRotation.x = 90;
				} 
				else if(xAxisClamp < -90) 
				{
					xAxisClamp = -90;
					cameraRotation.x = 270;
				}

				transform.rotation = Quaternion.Euler(cameraRotation);
				playerBody.rotation = Quaternion.Euler(playerRotation);  
			}

			yield return null;
		}
	}
}
