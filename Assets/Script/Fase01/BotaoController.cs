using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoController : MonoBehaviour
{
    private GameObject plataforma;
    void Start()
    {
        plataforma = GameObject.Find("PlataformaMadeiraTrigger");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            plataforma.GetComponent<PlataformaController>().enabled = true;
        }

	}
}
