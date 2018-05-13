using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoDisparo : MonoBehaviour {

	public Rigidbody2D Disp;
	public float VelDisp = 2f;
	public float DurDisp = 3f;


	// Use this for initialization
	void Start () 
	{
		DurDisp = Time.time + DurDisp;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Disp = gameObject.GetComponent<Rigidbody2D> ();
		Disp.velocity = transform.right * VelDisp;
		if (DurDisp <= Time.time)
			Destroy(gameObject);

	}

	void OnTriggerEnter2D(Collider2D Otro)
	{
		if (Otro.tag == "Enemy")
		{
			// Stops GameObject2 moving
			Debug.Log("Choco ");
			Destroy(this.gameObject);

		}

	}
}
