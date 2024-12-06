using SimpleInputNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[Header("Atributos do Player")]
	[SerializeField] private float velocidadeMovimento = 2.5f; // define a velocidade que o player anda
	[SerializeField] private float forçaDoPulo = 15f; // define a força do pulo do player
	private int maxHP = 5; // define o HP máximo do player
	private int hpAtual; // define o HP atual do player
	[SerializeField] private int pontosVidaExtra = 10; // Pontuação necessária para ganhar vida extra
	private GameObject myCamera;
	[SerializeField] private GameObject gameOver, ataqueAgua;
	[SerializeField] private float velocidadeAtaqueAgua = 5f;
	[SerializeField] private GameObject[] coracoes = new GameObject[5];
	private bool isVivo;
	[SerializeField] private bool isGrounded = false;
	Animator animator;
	private Vector3 posicaoAtual;
	[SerializeField] private bool isNadando;
	[SerializeField] private float timeBtwAttack;
	[SerializeField] private Transform attackPos;
	[SerializeField] private LayerMask whatIsEnemies;
	[SerializeField] private float attackRange;
	[SerializeField] private int dano;
	[SerializeField] private float resistênciaNaÁgua = 0.5f;
	[SerializeField] private Joystick joystick;
	[SerializeField] private bool forceUseMobileInput;

	private Rigidbody2D rb;
	private SpriteRenderer spriteRenderer;
	private Weapon weapon;

	[SerializeField] private int pontosAcumulados = 0;

	private void Start()
	{
		timeBtwAttack = 0.5f;
		dano = 1;
		isNadando = false;
		posicaoAtual = transform.position;
		isVivo = true;
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		weapon = GetComponentInChildren<Weapon>(); // nunca vai achar
		hpAtual = maxHP;
		myCamera = GameObject.Find("Main Camera");
		animator = GetComponentInChildren<Animator>();
	}

	private void Update()
	{
		if (transform.position.y < -4.2 && !isGrounded)
		{
			isNadando = true;
		}
		if (transform.position.y > 0)
		{
			isNadando = false;
		}
		if (isGrounded)
		{
			posicaoAtual = transform.position;
		}
		if ((Input.GetButtonDown("Jump") && isGrounded) || (Input.GetButtonDown("Jump") && isNadando))
		{
			Pular();
		}
		if (isGrounded)
		{
			animator.SetBool("isJumping", !isGrounded);
		}
		else
		{
			animator.SetBool("isJumping", !isGrounded);
		}
		atacar();


	}

	public void atacar()
	{
		if (isGrounded)
		{
			if (timeBtwAttack <= 0)
			{
				if (Input.GetButtonDown("Fire1"))
				{
					Collider2D[] inimigos = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
					for (int i = 0; i < inimigos.Length; i++)
					{
						inimigos[i].GetComponent<Enemy>().ReceberDano(dano);
					}
					animator.SetTrigger("Attack");
					timeBtwAttack = 0.5f;
				}
			
			}
			else
			{
				timeBtwAttack -= Time.deltaTime;
			}
		}
		if (isNadando)
		{
			if (timeBtwAttack <= 0)
			{
				if (Input.GetButtonDown("Fire1"))
				{
					GameObject ataque = Instantiate(ataqueAgua, attackPos.position, Quaternion.identity);
					Rigidbody2D rb = ataque.GetComponent<Rigidbody2D>();
					if (rb != null)
					{
						rb.velocity = Vector2.right * velocidadeAtaqueAgua;
					}
					timeBtwAttack = 0.7f;
				}
				
			} else
			{
				timeBtwAttack -= Time.deltaTime;
			}
		}

	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPos.position, attackRange);
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

		float movimento = Movimentacao();
		rb.velocity = new Vector2(movimento * velocidadeMovimento, rb.velocity.y);
		// Animação andando/parado e pulando/caindo
		animator.SetFloat("XVelocity", Math.Abs(rb.velocity.x));
		spriteRenderer.flipX = movimento < 0;
		animator.SetFloat("YVelocity", rb.velocity.y);
	}

	public float Movimentacao()
	{
        if (forceUseMobileInput || Application.isMobilePlatform)
        {
			return joystick.xAxis.value;
        } else
		{
			return Input.GetAxisRaw("Horizontal");
		}

    }
	public void Pular()
	{
		if (!isGrounded && !isNadando)
		{
			return;
		}
		if (isNadando)
		{
			// Adicionar força para simular "nado"
			rb.velocity = new Vector2(rb.velocity.x, forçaDoPulo/5);

			// Simular gravidade reduzida (flutuação)
			rb.velocity += new Vector2(0, -Physics2D.gravity.y * resistênciaNaÁgua * Time.fixedDeltaTime);
		}


		rb.AddForce(new Vector2(0f, forçaDoPulo), ForceMode2D.Impulse);
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

	public bool getIsNadando()
	{
		return isNadando;
	}

	public void setIsGrounded(bool isGrounded)
	{
		this.isGrounded = isGrounded;
	}

	public bool getIsGrounded()
	{
		return isGrounded;
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

		if (collision.gameObject.CompareTag("Inimigo"))
		{
			TomarDano(1);
		}
		if (collision.gameObject.CompareTag("Ataque"))
		{
			TomarDano(1);
			Destroy(collision.gameObject);
		}
		if (collision.gameObject.CompareTag("Fim"))
		{
			SceneManager.LoadScene("Tela inicial");
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

	}


}