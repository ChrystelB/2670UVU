using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int currentHealth;

	public ElementManager elementManager;
	private SO_Elemental.elementType elementType;

	private Rigidbody RB;
	private CharacterController CC;
    private EnemyNavigation eNav;
	private bool isMoveable = false;
	private bool usesCC;
    private bool usesNav;

	void Start(){
		Setup ();
	}

	void Setup(){																			//Determines if there is a character controller or a rigidbody attached
		RB = GetComponent<Rigidbody>();
		CC = GetComponent<CharacterController>();
        eNav = GetComponent<EnemyNavigation>();
		elementManager = GetComponent<ElementManager>();

		if (CC != null) {
			isMoveable = true;
			usesCC = true;
		}
        if (eNav != null) {
            isMoveable = true;
            usesNav = true;
            usesCC = false;
        }
		if (RB != null) {
			CC = null;
			isMoveable = true;
			usesCC = false;
		}
	}

	public void TakeDamage(int _dam, int _kBForce, SO_Elemental.elementType damElement, Vector3 _dir )		//takes the damage, knockback force, element, and force direction
	{
		SO_Elemental _so_Elemental = elementManager.currentElemental.GetComponent<ElementalController>().so_Elemental;


		//if the damager's element is not NEUTRAL
		if ((int)damElement != 0)															
		{
			//if the damager's element is weak against the damager's element, apply double damage
			if (_so_Elemental.elementStrengthOne == damElement || _so_Elemental.elementStrengthTwo == damElement)
			{	
				currentHealth += _dam / 2;
			}

			//if the damager's element is strong against the damager's element, apply double damage
			if (_so_Elemental.elementWeakness == damElement)
			{	
				currentHealth += _dam * 2;
			}
		}
		
		else
		{
			currentHealth += _dam;
		}													//if there are no elements just apply damage normally

        print(currentHealth);

		//_dir = calculateForce (_dir, currentHealth * .01f , _kBForce *.05f);			    //calculates the force to be applied to the object
		_dir = calculateForce(_dir, currentHealth, .01f) + calculateForce(_dir, _kBForce, .05f);		//trying different ways of calculating the force

		if(isMoveable){																        //determines if the object can be moved
            if (usesNav){
                StartCoroutine(ApplyForceNav(_dir));
            }else {
			    if (usesCC) {																//if it has a character controller
				    StartCoroutine (ApplyForceCC (_dir));									//use the character controller mehtod of adding force
			    } else { AddForce( _dir, RB); }												//else, ie if it has a RB, add force using the RB method
            }
		}
	}

	Vector3 calculateForce(Vector3 _forceVec, float num, float num2){						//simple way to multiply vector3s by floats or ints (i do it a few times)
		_forceVec.x *= num2 * num;
		_forceVec.y *= num2 * num;
		_forceVec.z *= num2 * num;
		return _forceVec;
	}

	public void AddForce(Vector3 _force, Rigidbody _RB){									//RB overload method of adding force
		RB.AddForce (calculateForce (_force, 30f , 1f), ForceMode.VelocityChange);			//uses the force vector and a multiplyer to add force to the object
	}

	public Vector3 AddForce(Vector3 _force, CharacterController _CC){						//CC overload method of adding force
		_CC.Move (_force);																	//uses move method to move the character
		return _force -= calculateForce (_force, Time.deltaTime, 3f);						//applys a negitive acceleration to the force (slows it down)
	}

	IEnumerator ApplyForceCC(Vector3 _impactForce){											//Coroutine used by CC
		Vector3 _force = _impactForce;														//stores the initial force on a temp varaible
		while(Vector3.Distance(_force, Vector3.zero) > .1f){								//enclosing loop, while there is still force to be applied
			_force = AddForce(_force ,CC);													//Method call to apply forces to the CC
			yield return null;																//wait a frame before going around again
		}
	}

    IEnumerator ApplyForceNav(Vector3 _impactForce){                                        //Coroutine used by CC
        Vector3 _force = _impactForce;                                                      //stores the initial force on a temp varaible
        while (Vector3.Distance(_force, Vector3.zero) > .1f){                               //enclosing loop, while there is still force to be applied
            eNav.ApplyForce(_force, true);                                                  //Method call to apply forces to the NavMesh
            _force -= calculateForce(_force, Time.deltaTime, 3f);
            yield return null;                                                              //wait a frame before going around again
        }
        eNav.ApplyForce(_force, false);
    }
}