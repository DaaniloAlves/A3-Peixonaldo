using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float velocidadeDoPaddle;
    public float xMinimo;
    public float xMaximo;

    // Variável para rastrear a direção atual
    private bool olhandoParaDireita = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentoDoPaddle();
    }

    private void MovimentoDoPaddle()
    {
        // Limitar a posição do paddle dentro dos limites
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, xMinimo, xMaximo), transform.position.y);

        // Obter a entrada do eixo horizontal
        float movimentoHorizontal = Input.GetAxisRaw("Horizontal");

        if (movimentoHorizontal > 0.01f)
        {
            // Mover para a direita
            transform.Translate(Vector2.right * velocidadeDoPaddle * Time.deltaTime);

            // Verificar e ajustar a direção do flip
            if (!olhandoParaDireita)
            {
                Flip();
            }
        }
        else if (movimentoHorizontal < -0.01f)
        {
            // Mover para a esquerda
            transform.Translate(Vector2.left * velocidadeDoPaddle * Time.deltaTime);

            // Verificar e ajustar a direção do flip
            if (olhandoParaDireita)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        // Inverter a variável que rastreia a direção
        olhandoParaDireita = !olhandoParaDireita;

        // Inverter a escala no eixo X
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
