using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] float vida = 10f;  // alterar a vida do inimigo


	public void ReceberDano(float dano)
	{
		vida -= dano;
		if (vida <= 0)
		{
			Morrer();
		}
	}

	private void Morrer()
	{
		Destroy(gameObject);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("AtaquePlayer"))
		{
			ReceberDano(1); // valor de teste
		}
	}
}