using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	private Player player; // gameobject do player
	[SerializeField] private Transform myCamera; // transform da camera 
	[SerializeField] private TextMeshProUGUI txtScore; // texto da pontuaçao
													   //[SerializeField] private GameObject heart; // gameobject do coraçao
													   //[SerializeField] private GameObject hearts[]; // vetor dos corações, usado para mostrar a quantidade de vida na interface
													   //[SerializeField] private GameObject emptyHearts[]; // vetor dos corações vazios que vao ficar sendo mostrados quando o player perder um coraçao
	[SerializeField] private GameObject gaivota;
	[SerializeField] private bool isPaused;
	[SerializeField] private GameObject pause;
	[SerializeField] private GameObject boss;
	private bool bossInstanciado = false;
	private bool gaivotaMorta = false;

	void Start()
	{

		Instantiate(gaivota, new Vector3(10, 4, 0), Quaternion.identity);
		player = FindObjectOfType<Player>(); // achando o gameobject do player assim que começa a rodar
		isPaused = false;
	}


	void Update()
	{
		if (player.transform.position.x < -12.9)
		{
			myCamera.position = new Vector3(-12.9f, player.transform.position.y, -10);
		} else if (player.transform.position.x > 280)
		{
			myCamera.position = new Vector3(280, player.transform.position.y, -10);
		}
		else if (player.transform.position.y > -10 && player.getIsNadando())
		{
			if (!gaivotaMorta)
			{
				Destroy(gaivota);
				gaivotaMorta=true;
			}
			myCamera.position = new Vector3(player.transform.position.x, -10, -10); // fazendo a camera seguir o player, passando o transform.position
		} else if (player.transform.position.y < 0 && !player.getIsNadando())
		{
			myCamera.position = new Vector3(player.transform.position.x, 0, -10); // fazendo a camera seguir o player, passando o transform.position
		} 
		else
		{
			myCamera.position = new Vector3(player.transform.position.x, player.transform.position.y, -10); // fazendo a camera seguir o player, passando o transform.position
		}
		 txtScore.text = player.getPontos().ToString(); // atualizando a interface da pontuaçao

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			pause.SetActive(true);
			isPaused = true;
			Time.timeScale = 0;
			
			
		}

		
		if (player.transform.position.x > 200 && player.transform.position.y < -28)
		{
			if (!bossInstanciado) { Instantiate(boss, new Vector3(235.09f, -32.15f, -0.5285227f), Quaternion.identity); bossInstanciado = true; }
		}
	}

	public void restartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void pausar()
	{
		pause.SetActive(true);
		isPaused = true;
		Time.timeScale = 0;
	}

	public void menu()
	{
		SceneManager.LoadScene("Tela inicial");
	}
	public void backToGame()
	{
		Time.timeScale = 1;
		pause.SetActive(false);
		isPaused = false;

	}
	public void quit()
	{
		Application.Quit();
	}
}