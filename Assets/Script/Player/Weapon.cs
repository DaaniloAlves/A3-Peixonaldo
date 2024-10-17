using UnityEngine;

public class Weapon : MonoBehaviour
{
	private float dano = 1f;                  // Dano da arma padrão
	private float raioAtaque = 0.5f;
	// private LayerMask inimigoLayer;
	[SerializeField] Transform posicaoAtaque;

	public void Atacar(Animator animator)
	{
		// inimigoLayer = "Inimigo";
		animator.SetTrigger("Ataque");
		DetectarInimigos();
	}

	private void DetectarInimigos()
	{
		// Detecta os inimigos na área do ponto de ataque
		Collider2D[] inimigos = Physics2D.OverlapCircleAll(posicaoAtaque.position, raioAtaque, 1);

		// Aplica dano pra cada inimigo na área
		foreach (Collider2D inimigo in inimigos)
		{
			inimigo.GetComponent<Enemy>()?.ReceberDano(dano);
		}
	}

	private void OnDrawGizmosSelected() //Isso creio que sirva pra desenhar a área do ataque.
	{
		if (transform != null)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, raioAtaque);
		}
	}

	public void AtivarPowerUp()
	{
		dano *= 1.5f;
		Debug.Log("Power-up ativado! Dano aumentado para: " + dano);
	}
}