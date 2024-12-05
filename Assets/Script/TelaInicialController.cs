using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicialController : MonoBehaviour
{
	[SerializeField] GameObject main;
	[SerializeField] GameObject fases;
	[SerializeField] GameObject credits;


	public void fase1()
	{
		SceneManager.LoadScene(1);
	}

	public void jogar()
	{
		//GameObject.Find("ConjuntoBackgrounds").transform.position = new Vector3(2876, 540, 0);
		main.SetActive(false);
		fases.SetActive(true);
		credits.SetActive(false);
	}

	public void creditos()
	{
		//GameObject.Find("ConjuntoBackgrounds").transform.position = new Vector3(-956, 540, 0);
		main.SetActive(false);
		fases.SetActive(false);
		credits.SetActive(true);
	}
	public void voltar()
	{
		//GameObject.Find("ConjuntoBackgrounds").transform.position = new Vector3(960, 540, 0);
		main.SetActive(true);
		fases.SetActive(false);
		credits.SetActive(false);
	}
}
