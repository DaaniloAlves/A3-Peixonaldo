using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	private Player player; // gameobject do player
	[SerializeField] private Transform myCamera; // transform da camera 
	[SerializeField] private TextMeshProUGUI txtScore; // texto da pontua�ao
													   //[SerializeField] private GameObject heart; // gameobject do cora�ao
													   //[SerializeField] private GameObject hearts[]; // vetor dos cora��es, usado para mostrar a quantidade de vida na interface
													   //[SerializeField] private GameObject emptyHearts[]; // vetor dos cora��es vazios que vao ficar sendo mostrados quando o player perder um cora�ao
	[SerializeField] private GameObject gaivota;

	void Start()
	{

		Instantiate(gaivota, new Vector3(10, 4, 0), Quaternion.identity);
		player = FindObjectOfType<Player>(); // achando o gameobject do player assim que come�a a rodar
	}


	void Update()
	{
		if (player.transform.position.x < -12.9)
		{
			myCamera.position = new Vector3(-12.9f, player.transform.position.y, -10);
		} else if (player.transform.position.x > 175)
		{
			myCamera.position = new Vector3(175, player.transform.position.y, -10);
		} else if (player.transform.position.y < 0)
		{
			myCamera.position = new Vector3(player.transform.position.x, 0, -10); // fazendo a camera seguir o player, passando o transform.position
		} else
		{
			myCamera.position = new Vector3(player.transform.position.x, player.transform.position.y, -10); // fazendo a camera seguir o player, passando o transform.position
		}
		 txtScore.text = player.getPontos().ToString(); // atualizando a interface da pontua�ao
	}

	public void restartGame()
	{
		SceneManager.LoadScene("Fase1");
	}
}