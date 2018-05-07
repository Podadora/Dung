using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputUsuario : MonoBehaviour {

public float movim = 2;
public float burst = 3;
public Animator Anim;
private bool Band = false;



void Start (){
			
}

void Update () {
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
}
