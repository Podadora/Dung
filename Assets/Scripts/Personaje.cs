using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {
	
	//IMPORTANTE!
	//Aca estamos declarando una variable de tipo GameObject, a diferencia de
	//Las variables que veniamos usando antes (float, int, bool) esta variable va a
	//Guardar la informacion sobre un GameObject (prefab)
	//Para llenar el varor de esta variable tenemos que arrastrar un prefab
	//Que tenemos en la carpeta de proyecto a la caja que se genero en el editor
	public GameObject bala;
	

	void Start () {
		//Invoke Repeating repite el llamado a una funcion cada x cantidad de tiempo
		InvokeRepeating("Disparar", 1f, 1f);
	}
	

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			Disparar();
		}
	}
	
	//Declaramos una funcion que se llama disparar
	//Dentro de ella vamos a poner todo el codigo relacionado a este evento
	void Disparar(){
		//Creamos una bala en la posicion  y rotacion actual de nuestro gameObject (personaje)
		Instantiate(bala, gameObject.transform.position, gameObject.transform.rotation);
	}
}
