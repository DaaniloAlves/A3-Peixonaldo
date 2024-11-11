using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaController : MonoBehaviour
{
    [SerializeField] private float velocidade = 2f;
    [SerializeField] private Transform posicao1, posicao2;
    [SerializeField] private Vector2 targetPos;
    void Start()
    {
        targetPos = posicao2.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posicao1.position) < 1f) targetPos = posicao2.position;
		if (Vector2.Distance(transform.position, posicao2.position) < 1f) targetPos = posicao1.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, velocidade * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
        {
			collision.transform.SetParent(null);
		}
	}
}
