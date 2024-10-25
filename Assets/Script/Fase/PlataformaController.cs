using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaController : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] private bool seMove = true;
	// variavel para identificar para qual direcao a plataforma vai comecar se movimentado
    // 0 = nenhum 1 = esquerda, 2 = cima, 3 = direita, 4 = baixo
	[SerializeField] private int start = 0;
    [SerializeField] private float limite = 1; // variavel para identificar quanto que a plataforma deve andar até parar
    [SerializeField] private float velocidade = 1;
    //private GameObject player;
    private float posicaoInicioMove; // variavel para gravar onde que a plataforma para, parar se mover de novo na direcao contraria
    private float posicaoFinalMove;
    [SerializeField] private float timerParado = 2;

	void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        //player = GameObject.Find("Player");
        switch (start)
        {
                case 1:
                posicaoInicioMove = transform.position.x; break;
                case 2:
                posicaoInicioMove = transform.position.y; break;
                case 3:
                posicaoInicioMove = transform.position.x; break;
                case 4:
                posicaoInicioMove = transform.position.y; break;
                default:
                posicaoInicioMove = 0;
                break;
        }
        //Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        posicaoFinalMove = posicaoInicioMove + limite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void FixedUpdate()
	{
		identificarDirecao();
	}


	// método que idenfica se a plataforma deve ir pra vertical ou horizontal e faz a movimentaçao
	private void identificarDirecao()
    {
        Debug.Log(posicaoFinalMove);
        if (seMove)
        {
            if (transform.position.x == posicaoFinalMove || transform.position.y == posicaoFinalMove)
            {
                timerParado -= Time.deltaTime;
            }
            else if (timerParado != 0)
            {
                switch (start)
                {
                    case 1:
                        rb.velocity = Vector2.left * velocidade;
                        timerParado = 2;
                        break;
                    case 2:
                        rb.velocity = Vector2.up * velocidade;
						timerParado = 2;
						break;
                    case 3:
                        rb.velocity = Vector2.right * velocidade;
						timerParado = 2;
						break;
                    case 4:
                        rb.velocity = Vector2.down * velocidade;
						timerParado = 2;
						break;
                    default:
                        break;
                }
            }
        }
    }

}
