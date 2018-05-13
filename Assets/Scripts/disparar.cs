using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparar : MonoBehaviour {

    public Rigidbody2D pelota;
    public float speedforce = 12f;
	private GameObject AngDisp;
	private Transform Rot;
	private float DispTime ;
	public float Reit = 0.2f;

   	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		AngDisp = GameObject.FindGameObjectWithTag ("AngDisp");
		Rot = AngDisp.GetComponent<Transform> ();

		if (Input.GetButton("Fire1") && DispTime <= Time.time )
        {
			tirito(Rot);
			DispTime = Time.time + Reit;
		}    
	}
	void tirito(Transform Ang)
	{	
		Vector2 Dird = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 Dirp = transform.position;
		Instantiate(pelota, transform.position, Rot.rotation);
		//pelotaClon.velocity = new Vector2 ((Dird.x - Dirp.x)*speedforce,(Dird.y-Dirp.y)*speedforce);
		Debug.Log ("Tirito");
		//pelotaClon.transform.position = Vector3.MoveTowards(Dirp, Dird, speedforce);

	}
}
