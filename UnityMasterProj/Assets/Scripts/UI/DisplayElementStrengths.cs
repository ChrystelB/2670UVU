using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayElementStrengths : MonoBehaviour {

	[Tooltip("List should match order of elementPathImgs in hierarchy")]
	public List<Image> elementPathImgs;

	[Tooltip("Element 0 must be left blank")]
	public List<Image> elementGemImgs;

	public Image activeElementGlow;

	public Material strongMat;
	public Material weakMat;
	public Material inactiveMat;

	public GameObject player;
	private ElementManager elementManager;

	public void StartGame()
	{
		elementManager = player.GetComponent<ElementManager>();
	}

	public void Display()
	{
		Image _elementStrengthOneImg;
		Image _elementStrengthTwoImg;
		Image _elementWeaknessImg;
		Image _activeElementGemImg;

		SO_Elemental _elemental;

		//saves player's current element to a temp variable
		_elemental = elementManager.currentElemental.GetComponent<ElementalController>().so_Elemental;

		//checks player's current animal SO for strength and weakness data
		_elementStrengthOneImg = elementPathImgs[_elemental.elementStrengthPathOne];
		_elementStrengthTwoImg = elementPathImgs[_elemental.elementStrengthPathTwo];
		_elementWeaknessImg = elementPathImgs[_elemental.elementWeaknessPath];

		//resets all element paths to inactivePathMat
		foreach (Image i in elementPathImgs)
		{
			i.color = inactiveMat.color;
		}

		//moves the appropriate elementPathImgs to the front of their component for proper display
		_elementStrengthOneImg.transform.SetAsLastSibling();
		_elementStrengthTwoImg.transform.SetAsLastSibling();
		_elementWeaknessImg.transform.SetAsLastSibling();

		//changes color of strength and weakness paths
		_elementStrengthOneImg.color = strongMat.color;
		_elementStrengthTwoImg.color = strongMat.color;
		_elementWeaknessImg.color = weakMat.color;
		
		//makes active element glow
		_activeElementGemImg = elementGemImgs[(int)_elemental.type];
		activeElementGlow.transform.position = _activeElementGemImg.transform.position;
	}
}