using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ABS_Elemental : ScriptableObject{
	public new string name;

	public enum elementType
	{
	NEUTRAL,
	EARTH,
	FIRE,
	LIGHTNING,
	WATER,
	WIND
	}

	public Sprite symbol;
	public elementType type;
	public elementType elementStrengthOne;
	public elementType elementStrengthTwo;
	public elementType elementWeakness;

	public int elementStrengthPathOne;
	public int elementStrengthPathTwo;
	public int elementWeaknessPath;
}