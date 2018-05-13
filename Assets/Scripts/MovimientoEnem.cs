using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovimientoEnem : MonoBehaviour {

	public Rigidbody2D Enemi;
	public GameObject target;
	private Collider2D Otro;
	public float VelEn = 5f;
	public float HPMax = 20;
	public float CalcMov = 0.03f;
	private float Posx = 0f;
	private float Posy = 0f; 
	public Vector2 PosRel;
	public GameManager ScrScore;

	// Barra HP
	public RectTransform VerdeHP;
	private float HPAct;


	public Animator AnimZomb;
	// Use this for initialization
	void Start () {
		//Vector3 PosHP = new Vector3 (transform.position.x + 4, transform.position.y, transform.position.z);
		//Instantiate(BarraHP, PosHP,transform.rotation);
		HPAct = HPMax;

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



		if (HPAct <= 0)
		{
			ScrScore = target.GetComponent<GameManager> ();
			ScrScore.Score += 1;
			Destroy (gameObject);
		}



	}

	void OnTriggerEnter2D(Collider2D Otro)
	{
		if (Otro.tag == "Disparo")
		{
			// Stops GameObject2 moving
			HPAct -= 5 ;
			UpgradeHP ();
			Debug.Log("OnTriggerEnter2D");
		}
	}
	void UpgradeHP()
	{
		if(HPAct != HPMax)
		{
			float Ratio = HPAct / HPMax;  
			VerdeHP.localScale = new Vector2 (Ratio, 1);
		}
	}
}
