using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to player
public class ElementManager : MonoBehaviour {

	public Transform elementSlotOne;
	public Transform elementSlotTwo;

	private PlayerAnimCtrls playerAnimCtrls;

	public SO_Elemental.elementType currentElement = SO_Elemental.elementType.NEUTRAL;
	public List<GameObject> elementals;
	public GameObject currentElemental;

	//called with StartGameState GameEvent
	public void StartGame()
	{
		playerAnimCtrls = GetComponent<PlayerAnimCtrls>();

		elementals.Clear ();
		currentElement = SO_Elemental.elementType.NEUTRAL;
		currentElemental = null;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Q))
		{
			if (elementals.Count == 2)
			{
				SwapElements ();
			}
		}
	}

	void SwapElements()
	{
		GameObject _temp = elementals [1];
		elementals [1] = elementals [0];

		elementals [0] = _temp;
		currentElemental = _temp;

		elementals [1].transform.position = elementSlotOne.position;
		elementals [1].transform.parent = elementSlotOne;
		elementals [0].transform.position = elementSlotTwo.position;
		elementals [0].transform.parent = elementSlotTwo;
		currentElement = elementals[0].GetComponent<ElementalController>().so_Elemental.type;

		playerAnimCtrls.SwapElement();
	}
}
