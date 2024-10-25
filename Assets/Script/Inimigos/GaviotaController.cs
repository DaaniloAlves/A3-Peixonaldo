using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaviotaController : Enemy
{

	private Rigidbody2D rb;
	[SerializeField] private GameObject ataque; // coc� normal
	[SerializeField] private GameObject ataque02; // tolet�o
	private float controleTempo = 2f; // intervalo entre os ataques
	private Transform transformAtaque; // Transform que indica onde o ataque deve ser instanciado
	[SerializeField] private int HP; // vida da gaivota
	[SerializeField] private Transform camera; // pegando a camera para definir os limites abaixo
	[SerializeField] private bool passou = false;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		transformAtaque = transform.Find("Ataque"); // encontrando o transform com o nome ataque
		HP = 3;
		rb.velocity = Vector2.left * 2.5f;
	}


	void Update()
	{
		atacar();
		
	}

	// m�todo com l�gica que faz a gaivota atacar
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

	// m�todo com l�gica que faz a gaivota se movimentar

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("PontoCamera"))
		{
			if (!passou)
			{
				passou = true;
			} else
			{
				SpriteRenderer gaivota = GetComponentInChildren<SpriteRenderer>();
				if (gaivota.flipX == false)
				{
					gaivota.flipX = true;
				} else
				{
					gaivota.flipX = false;
				}
				rb.velocity *= new Vector2(-1, 0);
			}
		}
	}
}