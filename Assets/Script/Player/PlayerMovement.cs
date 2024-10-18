using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private float velocidadeMovimento = 5f;
	private float forçaDoPulo = 5f;
	private float velocidadeNado = 3f;
	[SerializeField] int score = 0;

	private Rigidbody2D rb;
	//private Animator animator;
	private Weapon weapon;

	private Vector2 move;
	[SerializeField] private bool emSolo;
	private bool nadando;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		//animator = GetComponent<Animator>();
		weapon = FindObjectOfType<Weapon>();  // A arma é um filho do player
	}

	void Update()
	{
		move.x = Input.GetAxisRaw("Horizontal");
		//animator.SetFloat("Horizontal", move.x);
		//animator.SetFloat("Velocidade", move.sqrMagnitude);

		if (Input.GetButtonDown("Pulo") && emSolo)
		{
			rb.AddForce(new Vector2(rb.velocity.x, forçaDoPulo));
			Debug.Log("Ta pulando seu bosta");
		}

		if (nadando)
		{
			move.y = Input.GetAxisRaw("Vertical");
		}
		else
		{
			move.y = 0;
		}

		if (Input.GetButtonDown("ataque1"))
		{
			//weapon.Atacar(animator);
		}
	}

	void FixedUpdate()
	{
		Vector2 targetPosition = rb.position + move *
			(nadando ? velocidadeNado : velocidadeMovimento) * Time.fixedDeltaTime;

		rb.MovePosition(targetPosition);
	}

	public int getScore()
	{
		return this.score;
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Chão"))
		{
			emSolo = true;
		}

		if (collision.gameObject.CompareTag("Água"))
		{
			nadando = true;
			//animator.SetBool("Nadando", true);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Chão"))
		{
			emSolo = false;
		}

		if (collision.gameObject.CompareTag("Água"))
		{
			nadando = false;
			//animator.SetBool("Nadando", false);
		}
	}

	// Usando Trigger para garantir que o chão seja detectado corretamente
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Chão"))
		{
			emSolo = true;
			Debug.Log("Player no chão");
		}

		if (collision.CompareTag("Água"))
		{
			nadando = true;
			// animator.SetBool("Nadando", true);
		}

		if (collision.CompareTag("PowerUp"))
		{
			weapon.AtivarPowerUp();
			Destroy(collision.gameObject);
		}
	}

}