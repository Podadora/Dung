using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour {

	// Use this for initialization
	public void IrAEscena (string NombreEscena)
	{
		SceneManager.LoadScene (NombreEscena);
	}
}
