using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] protected float velocidade = 1.3f;
	[SerializeField] protected float vida;  // alterar a vida do inimigo
	protected float dazedTime;
	[SerializeField] protected float startDazedTime;
	[SerializeField] protected SpriteRenderer spriteRenderer;
	[SerializeField] private Color corDano = Color.red;     // Cor ao tomar dano
	[SerializeField] private Color corNormal = Color.white;     // Cor ao tomar dano
	[SerializeField] private float duracaoPiscar = 0.2f;    // Duração do "piscar"
	private Color corOriginal;

	private void Start()
	{
		corOriginal = Color.white;
	}
	private void Update()
	{
		if (dazedTime <= 0)
		{
			velocidade = 1.3f;
		}
		else
		{
			velocidade = 0;
			dazedTime -= Time.deltaTime;
		}
	}

	private IEnumerator PiscarVermelho()
	{
		spriteRenderer.color = corDano; // Altera para a cor de dano
		yield return new WaitForSeconds(duracaoPiscar); // Aguarda um tempo
		spriteRenderer.color = corNormal; // Retorna à cor original
	}
		public void ReceberDano(float dano)
	{
		vida -= dano;
		if (vida <= 0)
		{
			Destroy(gameObject);
		}
		StartCoroutine(PiscarVermelho()); // Inicia a rotina para piscar vermelho
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("AtaquePlayer"))
		{
			ReceberDano(1);
			Destroy(collision.gameObject);
		}
	}
}