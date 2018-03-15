
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavigation : MonoBehaviour 
{
	Transform Player;
	NavMeshAgent nav;
    [HideInInspector] public bool forceApplied = false;
	   
	void Awake()
	{
		 Player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	void Start () 
	{
		nav = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
        if (!forceApplied)
		{
			nav.SetDestination(Player.position);
        }
	}

    public void ApplyForce(Vector3 _force, bool _applyingForce)
	{
        nav.Move(_force);
        forceApplied = _applyingForce;
    }
}
