using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Abstract player scriptable object
 * REMINDER: DO NOT INSTANTIATE
 * contains default player data
 */

public abstract class ABS_Player : ScriptableObject 
{
	public float lookSensitivity = 3.0f;

	public new string name;

	// This a generic group of variables related to jumping.
	public float gravity = 14.0f;
	public float jumpForce = 10.0f;
	public int jumpCount = 0;
	public int jumpLimit = 1;

	// This is a generic group of variables related to walking and running.
	public float walkSpeed = 5.0f;
	public float runSpeed = 10.0f;

	//temporarily moving to ElementManager class	
	/*public Elemental.elementType currentElement = Elemental.elementType.Neutral;
	public List<GameObject> animals;
	public GameObject currentAnimal;*/

	public Sprite charPortrait;

	//abstract function that allows the player to jump
	//parameter: player vertical velocity
	//returns: new player velocity based off jump
	public abstract float Jump(float _verticalVelocity);
	
	//abstract function that returns the player vertical velocity to default
	//parameter: player vertical velocity
	//returns: default vertical velocity
	public abstract float ApplyGravity(float _verticalVelocity);
	
	//abstract function that changes players speed to run or walk
	//parameter player speed
	//returns new speed
	public abstract float Run(float _speed);
}
