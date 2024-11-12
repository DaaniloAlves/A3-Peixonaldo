using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[Header("Atributos do Player")]
	[SerializeField] private float velocidadeMovimento = 5f; // define a velocidade que o player anda
	[SerializeField] private float forçaDoPulo = 15f; // define a força do pulo do player
	private int maxHP = 5; // define o HP máximo do player
	private int hpAtual; // define o HP atual do player
	[SerializeField] private int pontosVidaExtra = 10; // Pontuação necessária para ganhar vida extra
	private GameObject myCamera;
	[SerializeField] private GameObject gameOver;
	[SerializeField] private GameObject[] coracoes = new GameObject[5];
	private bool isVivo;
	[SerializeField] private bool isGrounded = false;
	Animator animator;	
	private Vector3 posicaoAtual;

	private Rigidbody2D rb;
	// public Animator animator;
	private SpriteRenderer spriteRenderer;
	private Weapon weapon;


	[Header("Configurações do pulo")]
	private Transform checadorDeChão;
	private LayerMask camadaChão;
	private float raioChecador = 0.2f;  // Aumentar o raio para detectar o chão 

	[SerializeField] private int pontosAcumulados = 0;

	private void Start()
	{
		posicaoAtual = transform.position;
		isVivo = true;
		rb = GetComponent<Rigidbody2D>();
		// animator = GetComponent<Animator>();
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		weapon = GetComponentInChildren<Weapon>(); // nunca vai achar
		hpAtual = maxHP;
		myCamera = GameObject.Find("Main Camera");
		animator = GetComponentInChildren<Animator>();
	}

	private void Update()
	{
		if (isGrounded)
		{
			posicaoAtual = transform.position;
		}

		// Log para ver se o emSolo está sendo detectado corretamente
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			Pular();
			animator.SetBool("isJumping", !isGrounded);
		}
		// Atacar
		if (Input.GetButtonDown("Ataque"))
		{
			// weapon.Atacar(animator);
		}
	}
	private void FixedUpdate()
	{
		if (isVivo)
		{
			Movimentar();
		}
	}

	private void Movimentar()
	{
		// Movimento horizontal
		float movimento = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(movimento * velocidadeMovimento, rb.velocity.y);
		// Animação andando/parado e pulando/caindo
		animator.SetFloat("XVelocity", Math.Abs(rb.velocity.x));
		spriteRenderer.flipX = movimento < 0;
		animator.SetFloat("YVelocity", rb.velocity.y);
	}
	private void Pular()
	{
		// Usando AddForce para pular
		rb.AddForce(new Vector2(0f, forçaDoPulo), ForceMode2D.Impulse);
		animator.SetBool("isJumping", !isGrounded);
	}

	public void TomarDano(int dano)
	{
		hpAtual -= dano;
		StartCoroutine(PiscarVermelho());

		for (int i = 4; i >= 0; i--)
		{
			if (coracoes[i].activeSelf)
			{
				coracoes[i].SetActive(false);
				break;
			}
			
		}

		if (hpAtual <= 0)
		{
			Morrer();
		}
	}

	private void Morrer()
	{
		// impossibilitando a movimentaçao ao morrer
		rb.velocity = Vector2.zero;

		// criando gameover ao morrer
		gameOver.SetActive(true);
		isVivo = false;

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
		yield return new WaitForSeconds(0.1f);
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
		if (collision.CompareTag("Chão"))
		{
			animator.SetBool("isJumping", isGrounded);
			isGrounded = true;
		}
	}

	private void MudarDeFase()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Carrega a próxima cena
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Espinho"))
		{
			TomarDano(1);
			transform.position = posicaoAtual;
		}
		if (collision.gameObject.CompareTag("Inimigo"))
		{
			TomarDano(1);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Chão"))
		{
			isGrounded = false;
			animator.SetBool("isJumping", !isGrounded);
			
		}
	}
}