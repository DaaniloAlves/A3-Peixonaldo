using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocidade de movimento do jogador
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Captura a entrada do jogador
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Atualiza o parâmetro isMoving do Animator baseado na entrada do jogador
        bool isMoving = movement != Vector2.zero;
        animator.SetBool("isMoving", isMoving);

        // Atualiza a direção do movimento
        if (isMoving)
        {
            if (movement.x > 0)
            {
                animator.SetInteger("direction", 1); // Direita
                if (!isFacingRight) Flip();
            }
            else if (movement.x < 0)
            {
                animator.SetInteger("direction", 3); // Esquerda
                if (isFacingRight) Flip();
            }
            else if (movement.y > 0)
            {
                animator.SetInteger("direction", 2); // Cima
            }
            else if (movement.y < 0)
            {
                animator.SetInteger("direction", 0); // Baixo
            }
        }
    }

    void FixedUpdate()
    {
        // Move o jogador usando o Rigidbody2D
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        // Inverte o valor de isFacingRight
        isFacingRight = !isFacingRight;

        // Multiplica a escala X por -1 para inverter a direção
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}