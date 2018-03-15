using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script is to be put on elementals
public class ElementPickup : MonoBehaviour {

	public GameObject player;

	private ElementManager elementManager;
	private PlayerAnimCtrls playerAnimCtrls;

	private ElementalAnimsCtrl elementalAnimsCtrl;
	private SO_Elemental so_Elemental;
	private Renderer rend;
	private bool mouseOver;

	//runs when animal is instantiated via MeteorManager
	void Start()
	{
		elementManager = player.GetComponent<ElementManager>();
		playerAnimCtrls = player.GetComponent<PlayerAnimCtrls>();

		elementalAnimsCtrl = GetComponent<ElementalAnimsCtrl>();		
		so_Elemental = GetComponent<ElementalController> ().so_Elemental;
		rend = GetComponent<Renderer> ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.E) && mouseOver == true)
		{
			PickUpElement ();
		}
	}

	void OnMouseOver()
	{
		mouseOver = true;
		rend.material.SetFloat ("_Outline", 1);
	}
	
	void OnMouseExit()
	{
		mouseOver = false;
		rend.material.SetFloat ("_Outline", 0);
	}
		
	void PickUpElement()
	{
		switch (elementManager.elementals.Count)
		{
			case 0:
				print("picking up first element");
				elementManager.elementals.Add (gameObject);
				elementManager.elementals [0] = gameObject;

				StartCoroutine(MoveToElementSlot(elementManager.elementSlotOne));

				elementManager.currentElemental = gameObject;
				elementManager.currentElement = so_Elemental.type;

				elementManager.elementals [0].GetComponent<Rigidbody> ().useGravity = false;
				elementManager.elementals [0].GetComponent<BoxCollider> ().isTrigger = true;

				break;

			case 1:
				print("picking up second element");
				elementManager.elementals.Add (gameObject);
				elementManager.elementals [1] = gameObject;

				StartCoroutine(MoveToElementSlot(elementManager.elementSlotTwo));

				elementManager.elementals [1].GetComponent<Rigidbody> ().useGravity = false;
				elementManager.elementals [1].GetComponent<BoxCollider> ().isTrigger = true;

				break;			
				
			case 2:
				print("dropping secondary element");
				DropElement ();
				elementManager.elementals [1] = gameObject;

				StartCoroutine(MoveToElementSlot(elementManager.elementSlotTwo));

				elementManager.elementals [1].GetComponent<Rigidbody> ().useGravity = false;
				elementManager.elementals [1].GetComponent<BoxCollider> ().isTrigger = true;

				break;
		}

		playerAnimCtrls.PickUpElement();
	}

	void DropElement()
	{
		elementManager.elementals [1].GetComponent<Rigidbody> ().useGravity = true;
		elementManager.elementals [1].GetComponent<BoxCollider> ().isTrigger = false;

		elementManager.elementals [1].transform.parent = null;

		playerAnimCtrls.PickUpElement();
		elementalAnimsCtrl.Idle();
	}

	IEnumerator MoveToElementSlot(Transform _elementSlot)
	{
		float moveTime = 0;

		while(moveTime < 1)
		{
			transform.position = Vector3.Lerp (transform.position, _elementSlot.position, moveTime);
			transform.rotation = Quaternion.Lerp (transform.rotation, _elementSlot.rotation, moveTime);
			
			moveTime += Time.deltaTime;

			yield return null;
		}

		transform.parent = _elementSlot;
		elementalAnimsCtrl.BeingCarried();
	}
}
