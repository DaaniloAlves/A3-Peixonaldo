using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlataformaController : MonoBehaviour
{
	[SerializeField] private bool cima, esquerda, eixoY, eixoX;
	private float velocidade = 1f;
	[SerializeField] private float posicaoFinal;
	private float posicaoInicial;

	private void Start()
	{
		if (eixoY)
		{
			posicaoInicial = transform.position.y;
		} else if (eixoX)
		{
			posicaoInicial = transform.position.x;
		}
	}

	private void Update()
	{
		if (cima && eixoY)
		{
			transform.Translate(Vector2.up * velocidade * Time.deltaTime);
		}
		if (transform.position.y > posicaoFinal && eixoY)
		{
			transform.Translate(Vector2.up * -velocidade * Time.deltaTime);
			cima = false;
		}
		if (transform.position.y < posicaoInicial && eixoY)
		{
			transform.Translate(Vector2.up * velocidade * Time.deltaTime);
			cima = true;
		}

		if (esquerda && eixoX)
		{
			transform.Translate(Vector2.left * velocidade * Time.deltaTime);
		}
		if (transform.position.x < posicaoFinal && eixoX)
		{
			transform.Translate(Vector2.left * -velocidade * Time.deltaTime);
			esquerda = false;
		}
		if (transform.position.x > posicaoInicial && eixoX)
		{
			transform.Translate(Vector2.left * velocidade * Time.deltaTime);
			esquerda = true;
		}

	}



}
