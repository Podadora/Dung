using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoDisparo : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D Otro)
	{
		if (Otro.tag == "Enemy")
		{
			// Stops GameObject2 moving
			Debug.Log("Choco ");
		}
		Destroy(this.gameObject);

	}
}
