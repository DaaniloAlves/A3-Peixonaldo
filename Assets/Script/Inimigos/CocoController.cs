using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    private float dano;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<Player>().TomarDano(20);
		}
		Destroy(gameObject);
	}

    public void ativarGravidade()
    {
        rb.gravityScale = 1;
    }

}
