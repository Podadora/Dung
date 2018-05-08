using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnem : MonoBehaviour {

	public Rigidbody2D Enemi;
	public GameObject target;
	private Collider2D Otro;
	public float VelEn = 5f;
	public int Vida = 20;
	public float CalcMov = 0.03f;
	public float Posx = 0f;
	public float Posy = 0f;
	public Vector2 PosRel;

	public Animator AnimZomb;
	// Use this for initialization
	void Start () {
		
	}
	 
	// Update is called once per frame
	void Update () {
		target = GameObject.FindGameObjectWithTag ("Playercito");
		Vector3 PosPer = target.transform.position;	
		float FixSpeed = VelEn * Time.deltaTime;
		Posx = transform.position.x;
		Posy = transform.position.y;


		transform.position = Vector3.MoveTowards (transform.position, PosPer, FixSpeed);
		PosRel = new Vector2((Posx - transform.position.x),(Posy - transform.position.y));


		if (PosRel.x < CalcMov && Posx < transform.position.x)
		{
			AnimZomb.SetBool ("Right", true);
			AnimZomb.SetBool("Left", false);
			AnimZomb.SetBool("Up", false);
			AnimZomb.SetBool("Down", false);
			Debug.Log ("Right");
		}
		if(PosRel.x > CalcMov && Posx > transform.position.x)
		{
			AnimZomb.SetBool("Left", true);
			AnimZomb.SetBool("Right", false);
			AnimZomb.SetBool("Up", false);
			AnimZomb.SetBool("Down", false);
			Debug.Log ("Left");
		}

		if (PosRel.y < CalcMov && Posy < transform.position.y)
		{
			AnimZomb.SetBool("Up", true);
			AnimZomb.SetBool("Left", false);
			AnimZomb.SetBool("Right", false);
			AnimZomb.SetBool("Down", false);
			Debug.Log ("Up");
		}
		if (PosRel.y > CalcMov && Posy > transform.position.y)
		{
			AnimZomb.SetBool("Down", true);
			AnimZomb.SetBool("Up", false);
			AnimZomb.SetBool("Left", false);
			AnimZomb.SetBool("Right", false);
			Debug.Log ("Down");
		}
		/*if (Posx - transform.position.x == 0)
		{
			AnimZomb.SetBool("Left", false);
			AnimZomb.SetBool("Right", false);
		}

		if (Posy - transform.position.y == 0)
		{
			AnimZomb.SetBool("Up", false);
			AnimZomb.SetBool("Down", false);
		}*/

		Posx = transform.position.x;
		Posy = transform.position.y;



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
