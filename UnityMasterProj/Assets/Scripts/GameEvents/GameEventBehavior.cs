using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

public class GameEventBehavior : StateMachineBehaviour {

	public GameEvent gameEvent;

	void OnStateEnter (){
		gameEvent.Raise();
		//Debug.Log(gameEvent);
	}
}
