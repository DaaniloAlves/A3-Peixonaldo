using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : Enemy
{

	[SerializeField] private Transform posicao1, posicao2, attackPos, player;
	[SerializeField] private Vector2 targetPos;
	private bool atacando = false;
	[SerializeField] private float controleAtaque = 3.5f;
	[SerializeField] private float controleSprite = 1f;
	[SerializeField] private GameObject ataque;
	[SerializeField] private Sprite spriteNormal;
	[SerializeField] private Sprite spriteAtaque;
	[SerializeField] private Sprite spriteMorto;
	private float velocidadeAtaque = 12f;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		velocidade = 2f;
		targetPos = posicao2.position;
		spriteRenderer.sprite = spriteNormal;
		player = GameObject.Find("Player").GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update()
	{
		movimentar();
		atacar();
		
	}

	public void movimentar()
	{
		if (Vector2.Distance(transform.position, posicao1.position) < 1f) targetPos = posicao2.position;
		if (Vector2.Distance(transform.position, posicao2.position) < 1f) targetPos = posicao1.position;
		transform.position = Vector2.MoveTowards(transform.position, targetPos, velocidade * Time.deltaTime);
	}

	public void atacar()
	{
		if (controleSprite <= 0f)
		{
			spriteRenderer.sprite = spriteNormal;
			spriteRenderer.flipX = false;
		}
		if (controleAtaque <= 0f)
		{
			spriteRenderer.sprite = spriteAtaque;
			spriteRenderer.flipX = true;

			// Instancie o objeto e salve a referência
			GameObject ataqueBoss = Instantiate(ataque, attackPos.position, Quaternion.identity);

			// Atribua a direção ao Rigidbody2D da instância
			Rigidbody2D rb = ataqueBoss.GetComponent<Rigidbody2D>();
			if (rb != null)
			{
				// Calcular direção do ataque em direção ao jogador
				Vector2 direcao = (player.position - attackPos.position).normalized;

				// Aplicar a velocidade ao ataque na direção do player
				rb.velocity = direcao * velocidadeAtaque;
			}

			// Reinicie o controle de ataque
			controleAtaque = 3.5f;
			controleSprite = 1f;
		}
		else
		{
			controleSprite -= Time.deltaTime;
			controleAtaque -= Time.deltaTime;
		}
		
	}
}

