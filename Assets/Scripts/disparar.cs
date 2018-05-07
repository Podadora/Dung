using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparar : MonoBehaviour {

    public Rigidbody2D pelota;
    public float speedforce = 12f;

    void tirito()
    {	
		Vector2 Dird = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 Dirp = transform.position;
        Rigidbody2D pelotaClon = (Rigidbody2D)Instantiate(pelota, transform.position, transform.rotation);
		pelotaClon.velocity = new Vector2 ((Dird.x - Dirp.x)*speedforce,(Dird.y-Dirp.y)*speedforce);
		//pelotaClon.transform.position = Vector3.MoveTowards(Dirp, Dird, speedforce);
	
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            tirito();
        }    
	}
}
