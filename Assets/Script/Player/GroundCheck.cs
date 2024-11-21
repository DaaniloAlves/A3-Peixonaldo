using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Animator animator;
	[SerializeField] private GameObject player;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Chão"))
		{
			animator.SetBool("isJumping", player.GetComponent<Player>().getIsGrounded());
			player.GetComponent<Player>().setIsGrounded(true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Chão"))
		{
			player.GetComponent<Player>().setIsGrounded(false);
			//animator.SetBool("isJumping", !player.GetComponent<Player>().getIsGrounded());


		}
	}
}
