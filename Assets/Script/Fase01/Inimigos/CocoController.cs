using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    private float timerDestruicao = 3f;

    private float dano;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        contarTimerDestruicao(); 
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<Player>().TomarDano(1);
			Destroy(gameObject);
		} 
	}

    private void contarTimerDestruicao()
    {
        timerDestruicao -= Time.deltaTime;
        if (timerDestruicao <= 0 )
        {
            Destroy(gameObject);
        }
    }

}
