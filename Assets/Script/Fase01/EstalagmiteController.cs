using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstalagmiteController : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
			rb.gravityScale = 1;
		}
        
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<Player>().TomarDano(1);
		}
		Destroy(gameObject);

	}
}
