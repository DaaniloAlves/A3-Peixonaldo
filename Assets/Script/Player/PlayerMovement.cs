using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[Header("Atributos do Player")]
	[SerializeField] private float velocidadeMovimento = 5f; // define a velocidade que o player anda
	[SerializeField] private float for�aDoPulo = 15f; // define a for�a do pulo do player
	[SerializeField] private int maxHP = 100; // define o HP m�ximo do player
	[SerializeField] private int hpAtual; // define o HP atual do player
	[SerializeField] private int pontosVidaExtra = 100; // Pontua��o necess�ria para ganhar vida extra
	[SerializeField] private GameObject myCamera;
	[SerializeField] private GameObject gameOver;

	private Rigidbody2D rb;
	// public Animator animator;
	private SpriteRenderer spriteRenderer;
	private Weapon weapon;

	[Header("Configura��es do pulo")]
	private Transform checadorDeCh�o;
	private LayerMask camadaCh�o;
	[SerializeField] private bool emSolo;
	private float raioChecador = 0.2f;  // Aumentar o raio para detectar o ch�o 

	[SerializeField] private int pontosAcumulados = 0;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		// animator = GetComponent<Animator>();
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		weapon = GetComponentInChildren<Weapon>();
		hpAtual = maxHP;
		myCamera = GameObject.Find("Main Camera");
	}

	private void Update()
	{
		// Movimento horizontal
		float movimento = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(movimento * velocidadeMovimento, rb.velocity.y);

		// Ativa a anima��o de andar
		// animator.SetFloat("Velocidade", Mathf.Abs(movimento));

		// Log para ver se o emSolo est� sendo detectado corretamente

		if (Input.GetButtonDown("Jump") && emSolo)
		{
			Pular();
		}

		// Atacar
		if (Input.GetButtonDown("Ataque"))
		{
			// weapon.Atacar(animator);
		}

		// Atualiza o valor booleano da anima��o de solo
		// animator.SetBool("EmSolo", emSolo);
	}

	private void Pular()
	{
		// Usando AddForce para pular
		rb.AddForce(new Vector2(0f, for�aDoPulo), ForceMode2D.Impulse);
		// animator.SetTrigger("Pular");
	}

	public void TomarDano(int dano)
	{
		hpAtual -= dano;
		StartCoroutine(PiscarVermelho());

		if (hpAtual <= 0)
		{
			Morrer();
		}
	}

	private void Morrer()
	{
		// animator.SetTrigger("Morrer");
		rb.velocity = Vector2.zero;

		// criando gameover ao morrer
		Instantiate(gameOver, new Vector3(myCamera.transform.position.x + 2, myCamera.transform.position.y, 0), Quaternion.identity);

		// Reinicia a cena atual
		// SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ColetarPonto(int pontos)
	{
		pontosAcumulados += pontos;

		if (pontosAcumulados >= pontosVidaExtra)
		{
			GanharVida(1);
			pontosAcumulados = 0;
		}
	}

	private void GanharVida(int quantidade)
	{
		hpAtual = Mathf.Min(hpAtual + quantidade, maxHP);
	}

	public void AtivarPowerUp()
	{
		weapon.AtivarPowerUp();
	}

	private IEnumerator PiscarVermelho()
	{
		spriteRenderer.color = Color.red;
		yield return new WaitForSeconds(0.1f);
		spriteRenderer.color = Color.white;
	}

	public float getPontos()
	{
		return pontosAcumulados;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("PowerUp"))
		{
			AtivarPowerUp();
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.CompareTag("Moeda"))
		{
			ColetarPonto(1);
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.CompareTag("FimDaFase"))
		{
			MudarDeFase();
		}
	}

	private void MudarDeFase()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Carrega a pr�xima cena
	}

	// Fun��es para verificar o ch�o usando colis�o
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Ch�o") || collision.gameObject.CompareTag("Espinho"))
		{
			emSolo = true;
		}
		if (collision.gameObject.CompareTag("Espinho"))
		{
			TomarDano(1);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Ch�o") || collision.gameObject.CompareTag("Espinho"))
		{
			emSolo = false;
		}
	}
}