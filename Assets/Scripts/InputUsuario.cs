using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputUsuario : MonoBehaviour {


//Variables barra HP
public Image Verde;
public Text Porcentaje;
public float HPAct;
public float MaxHP = 30;



//Variables de movimiento
public float movim = 2f;
public float burst = 3f;
public Animator Anim;
private bool Band = false;
public Rigidbody2D Player;


// Stats PJ
public float HP = 30;

// Variables de KnockBack
public int KnockForce = 5;
public bool Knockback = false;
public float KnockTime = 0f;
public float KnockStop = 0.5f;
public Transform Enemy;
public SpriteRenderer CambioColor;

//Variables Rotacion Arma
public float RotSpeed=5f;
public Transform Arma;


void Start (){
		HPAct = MaxHP;
}

void Update () {


		if(!Knockback)
		{
	if (Input.GetKey(KeyCode.LeftShift))
	{
		if(Input.GetKey(KeyCode.A))
		{ 
				gameObject.transform.Translate ((-movim * burst) * Time.deltaTime, 0,0);
				Anim.SetBool ("Left", true);
				Anim.SetBool ("Right", false);
				Anim.SetBool ("Up", false);
				Anim.SetBool ("Down", false);
				Band = true;
		}
		if(Input.GetKey (KeyCode.D))
		{
				gameObject.transform.Translate((movim * burst) * Time.deltaTime, 0,0);
				Anim.SetBool ("Right", true);
				Anim.SetBool ("Left", false);
				Anim.SetBool ("Up", false);
				Anim.SetBool ("Down", false);
				Band = true;
		}
		if (Input.GetKey(KeyCode.W))
		{
				gameObject.transform.Translate(0, (movim * burst)* Time.deltaTime,0);
				Anim.SetBool ("Up", true);
				Anim.SetBool ("Left", false);
				Anim.SetBool ("Right", false);
				Anim.SetBool ("Down", false);
				Band = true;
		}
		if (Input.GetKey(KeyCode.S))
		{
				gameObject.transform.Translate(0, (-movim * burst) * Time.deltaTime,0);
				Anim.SetBool ("Down", true);
				Anim.SetBool ("Up", false);
				Anim.SetBool ("Left", false);
				Anim.SetBool ("Right", false);
				Band = true;
		}
			print ("Entro al Shift");
			if (!Band)
			{
				Anim.SetBool ("Down", false);
				Anim.SetBool ("Up", false);
				Anim.SetBool ("Left", false);
				Anim.SetBool ("Right", false);
			}
			Band = false;
				
	}
	else
	{
			if(Input.GetKey(KeyCode.A))
			{
				gameObject.transform.Translate (-movim*Time.deltaTime, 0,0);
				Anim.SetBool ("Left", true);
				Anim.SetBool ("Right", false);
				Anim.SetBool ("Up", false);
				Anim.SetBool ("Down", false);
				Band = true;
			}
						if(Input.GetKey (KeyCode.D)){
				gameObject.transform.Translate(movim * Time.deltaTime, 0,0);
				Anim.SetBool ("Right", true);
				Anim.SetBool ("Left", false);
				Anim.SetBool ("Up", false);
				Anim.SetBool ("Down", false);
				Band = true;
			}
			if (Input.GetKey(KeyCode.W)){
				gameObject.transform.Translate(0, movim * Time.deltaTime,0);
				Anim.SetBool ("Up", true);
				Anim.SetBool ("Left", false);
				Anim.SetBool ("Right", false);
				Anim.SetBool ("Down", false);
				Band = true;
			}
			if (Input.GetKey(KeyCode.S)){
				gameObject.transform.Translate(0, -movim * Time.deltaTime,0);
				Anim.SetBool ("Down", true);
				Anim.SetBool ("Up", false);
				Anim.SetBool ("Left", false);
				Anim.SetBool ("Right", false);
				Band = true;
			}
			print ("No entro al Shift");
			if (!Band)
			{
				Anim.SetBool ("Down", false);
				Anim.SetBool ("Up", false);
				Anim.SetBool ("Left", false);
				Anim.SetBool ("Right", false);
			}
			Band = false;
		}
		
		}
		//Tiempo de dur de KNOCKBACK
		else if (Knockback)
		{
			if (KnockTime <= Time.time)
			{
				CambioColor = gameObject.GetComponent<SpriteRenderer> ();
				CambioColor.color = new Color (255, 255, 255);
				Debug.Log ("Aspapita");
				Knockback = false;
			}
		}

		Rotate ();



	}

	void OnTriggerEnter2D (Collider2D Otro)
	{
		if(Otro.tag == "Enemy")
		{
			Knockback = KnockBack(Otro);
			HPAct -= 5;
			UpgradeHP ();

		}
	}

	// Aquie funcionan el KNOCKBACK
	bool KnockBack (Collider2D Otro)
	{

	Debug.Log ("Chocaste");
	Vector2 Dire = Otro.transform.position;
	Vector2 Dirp = gameObject.transform.position;
	Player = gameObject.GetComponent<Rigidbody2D> ();
	Player.velocity = new Vector2 ((Dirp.x - Dire.x)*KnockForce,(Dirp.y-Dire.y)*KnockForce);
	KnockTime = Time.time + KnockStop;
	CambioColor = gameObject.GetComponent<SpriteRenderer> ();
	CambioColor.color = new Color (255, 0, 0);
	return true;
	}

	//Rotar arma principal
	void Rotate ()
	{
		//Arma = GetComponentInChildren<Transform> ();
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		Arma.rotation = Quaternion.Slerp(Arma.rotation, rotation, RotSpeed * Time.deltaTime);
	}

	void UpgradeHP()
	{
		if(HPAct != MaxHP)
		{
			float Ratio = HPAct / MaxHP;  
			Verde.rectTransform.localScale = new Vector2 (Ratio, 1);
			Porcentaje.text= (Ratio * 100).ToString () + "%";
		}
	}

}

