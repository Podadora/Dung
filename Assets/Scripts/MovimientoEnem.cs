using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnem : MonoBehaviour {

	public Rigidbody2D Enemi;
	public GameObject target;
	private Collider2D Otro;
	public float VelEn = 5f;
	public int Vida = 20;
	// Use this for initialization
	void Start () {
		
	}
	 
	// Update is called once per frame
	void Update () {
		target = GameObject.FindGameObjectWithTag ("Playercito");
		Vector3 PosPer = target.transform.position;	

		float FixSpeed = VelEn * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, PosPer, FixSpeed);

		if (Vida <= 0)
		{
			Destroy (gameObject);
		}


	}

	void OnTriggerEnter2D(Collider2D Otro)
	{
		if (Otro.tag == "Disparo")
		{
			// Stops GameObject2 moving
			Vida -= 5 ;
			Debug.Log("OnTriggerEnter2D");
		}
	}
}
