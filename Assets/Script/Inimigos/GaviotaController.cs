using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaviotaController : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private GameObject ataque;
    private float controleTempo = 2f;
    private Transform transformAtaque;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transformAtaque = transform.Find("Ataque");
    }

    
    void Update()
    {
        rb.velocity = Vector2.left * 2.5f;
        atacar();
    }

    void atacar()
    {
        controleTempo -= Time.deltaTime;
        if (controleTempo <= 0)
        {
            Vector3 v3 = new Vector3(transformAtaque.position.x, transformAtaque.position.y, transformAtaque.position.z);
            Instantiate(ataque, v3, transform.rotation);
            controleTempo = 2f;
        }
    }
}
