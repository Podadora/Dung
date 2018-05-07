using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarEnem : MonoBehaviour {
	
	public GameObject Enemigo;
	public int LimEnem = 20;
	public float TiempoDeRespawn = 0.3f;
	public float TiempoDeSpawn;

	// Use this for initialization

	void invoca()
	{	
		Instantiate(Enemigo, transform.position, transform.rotation);
		if (LimEnem == 0) 
		{
			CancelInvoke ("invoca");
		}
		LimEnem -= 1;
	}
	void Start () 
	{
		TiempoDeSpawn = TiempoDeRespawn;
		InvokeRepeating ("invoca", 2f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*TiempoDeSpawn -= Time.deltaTime;
		if (TiempoDeSpawn <= 0)
		{
			invoca ();
			TiempoDeSpawn = TiempoDeRespawn;
		}
		*/

	}
}