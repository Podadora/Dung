using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
	public static GameManager Instance;
	public InputUsuario Player;
	public int ScoreVictoria = 15;
	public int Score;
	public float HP;


	void Awake ()
	{
		if (Instance == null )
		{
			Instance = this;
		}
		else
		{
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		// Get Player current HP
		Player = gameObject.GetComponent<InputUsuario> ();
		HP = Player.HP;
	
		if (Score > ScoreVictoria )
		{
			Ganar ();
		}			
		else if (HP <= 0)
		{
			Perder ();
		}
	}
	void Ganar()
	{
		SceneManager.LoadScene ("WinLoose");
		ScoreVictoria += Score;
		Score = 0;

	}
	void Perder()
	{
		SceneManager.LoadScene ("WinLoose");
		Score = 0;
	}

}
