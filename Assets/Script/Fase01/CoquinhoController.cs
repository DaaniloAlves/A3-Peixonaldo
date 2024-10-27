using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoquinhoController : MonoBehaviour
{
    [SerializeField] private int dano = 20;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			GameObject player = GameObject.Find("Player");
			player.GetComponent<Player>().TomarDano(dano);
			Destroy(gameObject);
		}
		Destroy(gameObject);
	}
}
