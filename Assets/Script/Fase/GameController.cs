using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private Player player; // gameobject do player
	[SerializeField] private Transform myCamera; // transform da camera 
	[SerializeField] private TextMeshProUGUI txtScore; // texto da pontuaçao
													   //[SerializeField] private GameObject heart; // gameobject do coraçao
													   //[SerializeField] private GameObject hearts[]; // vetor dos corações, usado para mostrar a quantidade de vida na interface
													   //[SerializeField] private GameObject emptyHearts[]; // vetor dos corações vazios que vao ficar sendo mostrados quando o player perder um coraçao
	[SerializeField] private GameObject gaivota;

	void Start()
	{
		Instantiate(gaivota, new Vector3(10, 4, 0), Quaternion.identity);
		player = FindObjectOfType<Player>(); // achando o gameobject do player assim que começa a rodar
	}


	void Update()
	{
		myCamera.position = new Vector3(player.transform.position.x, 0, -10); // fazendo a camera seguir o player, passando o transform.position
		// txtScore.text = player.getScore().ToString(); // atualizando a interface da pontuaçao
	}

	// metodo terá que ser chamado quando o player perder ou ganhar vida
	//void controlarHearts()
	//{
	//    int playerHP = player.getHP();
	//    for (var heart in playerHP)
	//    {
	//        Instantiate()
	//    }
	//}
}