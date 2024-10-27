using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class NuvemController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float velocidade = 1.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		rb.velocity = Vector2.left * velocidade;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
