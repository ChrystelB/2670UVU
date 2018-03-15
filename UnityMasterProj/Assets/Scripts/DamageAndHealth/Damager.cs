using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

	public int baseDamage, baseKnockBack;										//the values for damage and knockback before elements are applied

	void OnTriggerEnter (Collider other) {			
		
		ElementManager elementManager = GetComponent<ElementManager>();
		Health objHealth = other.GetComponent<Health> ();						//gets the health script from the collider data, it pulls it either way so might as well use the data

		if (objHealth != null)
		{
			objHealth.TakeDamage (baseDamage, baseKnockBack, elementManager.currentElement, other.transform.position - this.transform.position);	//Damage the other thing, creature or player
		}
	}

}