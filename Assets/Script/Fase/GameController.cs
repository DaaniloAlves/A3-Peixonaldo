using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private PlayerMovement player; // gameobject do player
	[SerializeField] private Transform camera; // transform da camera
	[SerializeField] private TextMeshProUGUI txtScore; // texto da pontuaçao
													 //[SerializeField] private GameObject heart; // gameobject do coraçao
													 //[SerializeField] private GameObject hearts[]; // vetor dos corações, usado para mostrar a quantidade de vida na interface
													 //[SerializeField] private GameObject emptyHearts[]; // vetor dos corações vazios que vao ficar sendo mostrados quando o player perder um coraçao

	void Start()
	{
		player = FindObjectOfType<PlayerMovement>(); // achando o gameobject do player assim que começa a rodar
	}


	void Update()
	{
		camera.position = new Vector3(player.transform.position.x, 0, -10); // fazendo a camera seguir o player, passando o transform.position
		txtScore.text = player.getScore().ToString(); // atualizando a interface da pontuaçao
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