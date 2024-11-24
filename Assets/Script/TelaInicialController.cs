using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicialController : MonoBehaviour
{
	public void jogar()
	{
		SceneManager.LoadScene(1);
	}

	public void creditos()
	{
		GameObject.Find("ConjuntoBackgrounds").transform.position = new Vector3(-956, 540, 0);
	}
	public void voltar()
	{
		GameObject.Find("ConjuntoBackgrounds").transform.position = new Vector3(960, 540, 0);
	}
}
