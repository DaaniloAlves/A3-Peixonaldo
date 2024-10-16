using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float vida = 10f;  // alterar a vida do inimigo
	public void ReceberDano(float dano)
	{
		vida -= dano;
		Debug.Log("Inimigo recebeu dano: " + dano);

		if (vida <= 0)
		{
			Morrer();
		}
	}

	private void Morrer()
	{
		Debug.Log("Inimigo morreu!");
		Destroy(gameObject);
	}
}