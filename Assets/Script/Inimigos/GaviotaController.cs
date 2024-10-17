using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaviotaController : Enemy
{

	private Rigidbody2D rb;
	[SerializeField] private GameObject ataque; // cocô normal
	[SerializeField] private GameObject ataque02; // toletão
	private float controleTempo = 2f; // intervalo entre os ataques
	private Transform transformAtaque; // Transform que indica onde o ataque deve ser instanciado
	[SerializeField] private int HP; // vida da gaivota
	[SerializeField] private Transform camera; // pegando a camera para definir os limites abaixo
	private float limiteEsquerdo;// limite esquerdo da tela, usado para fazer a gaivota não sair nunca da tela
	private float limiteDireito; // limite direito da tela, usado para fazer a gaivota não sair nunca da tela


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		transformAtaque = transform.Find("Ataque"); // encontrando o transform com o nome ataque
		HP = 3;
		limiteEsquerdo = camera.position.x - (camera.localScale.x / 2);
		limiteDireito = camera.position.x + (camera.localScale.x / 2);
	}


	void Update()
	{
		atacar();
		movimentar();
	}

	// método com lógica que faz a gaivota atacar
	void atacar()
	{
		controleTempo -= Time.deltaTime; // decrementando 1 do tempo a cada segundo
		int chance = Random.Range(0, 10); // salvando um numero aleatorio em uma variavel chance
		if (controleTempo <= 0) // atacando apenas quando o controle estiver zerado
		{
			if (chance == 2) // se chance for 2, cague o toletao
			{
				Instantiate(ataque02, transformAtaque.position, transform.rotation); // criando o ataque
			}
			else // se chance for outro, cague fofo
			{
				Instantiate(ataque, transformAtaque.position, transform.rotation); // criando o ataque
			}
			controleTempo = 2f; // setando o intervalo do ataque de volta
		}
	}

	// método com lógica que faz a gaivota se movimentar
	void movimentar()
	{
		if (transform.position.x < limiteEsquerdo) // se movimentando para a direita se atingir o limite esquerdo
		{
			rb.velocity = Vector2.right * 2.5f;
		}
		else if (transformAtaque.position.x > limiteDireito)  // se movimentando para a esquerda se atingir o limite direito
		{
			rb.velocity = Vector2.left * 2.5f;
		}
	}
}