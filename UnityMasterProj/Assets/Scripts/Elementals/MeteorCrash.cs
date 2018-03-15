using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class MeteorCrash : MonoBehaviour {
	public Transform target;
	public List <GameObject> elementals;
	private Rigidbody rb;
	public float speed = 50f;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		transform.LookAt (target);
	}

	void Update()
	{
		rb.velocity = transform.forward * speed;
	}

	void OnCollisionEnter()
	{
		SpawnAnimal ();
	}

	void SpawnAnimal()
	{
		int type = Random.Range (0, elementals.Count - 1);
		GameObject _elemental = Instantiate (elementals[type]);
		_elemental.transform.position = transform.position;
		_elemental.SetActive (true);
		Destroy (this.gameObject);
	}
}