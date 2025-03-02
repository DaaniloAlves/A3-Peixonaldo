using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GaviotaController : Enemy
{

	private Rigidbody2D rb;
	[SerializeField] private GameObject ataque; // coc� normal
	[SerializeField] private GameObject ataque02; // tolet�o
	[SerializeField] private GameObject player;
	private float controleTempo = 2f; // intervalo entre os ataques
	private Transform transformAtaque; // Transform que indica onde o ataque deve ser instanciado
	[SerializeField] private Transform myCamera; // pegando a camera para definir os limites abaixo
	[SerializeField] private bool passou = false;
	private GameObject ponto1;
	private GameObject ponto2;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		transformAtaque = transform.Find("Ataque"); // encontrando o transform com o nome ataque
		rb.velocity = Vector2.left * 2.5f;
		ponto1 = GameObject.Find("Ponto1");
		ponto2 = GameObject.Find("Ponto2");
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
				if (collision.gameObject == ponto1)
				{
					gaivota.flipX = false;
					rb.velocity *= new Vector2(-1, 0);
					collision.gameObject.SetActive(false);
					ponto2.gameObject.SetActive(true);
				}
				else if (collision.gameObject == ponto2)
				{
					gaivota.flipX = true;
					rb.velocity *= new Vector2(-1, 0);
					collision.gameObject.SetActive(false);
					ponto1.gameObject.SetActive(true);
				}
				
			}
		}
	}
}