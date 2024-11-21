using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] protected float velocidade = 1.3f;
	[SerializeField] protected float vida;  // alterar a vida do inimigo
	protected float dazedTime;
	[SerializeField] protected float startDazedTime;
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
	public void ReceberDano(float dano)
	{
		dazedTime = startDazedTime;
		vida -= dano;
		if (vida <= 0)
		{
			Destroy(gameObject);
		}
	}
	
}