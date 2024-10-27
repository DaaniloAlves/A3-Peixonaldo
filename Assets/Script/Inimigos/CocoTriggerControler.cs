using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoTriggerControler : MonoBehaviour
{
    [SerializeField] private bool eventoAconteceu = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!eventoAconteceu)
        { 
        if (collision.CompareTag("Player"))
        {
                GameObject coco = GameObject.Find("CocoSprite");
                coco.GetComponent<Rigidbody2D>().gravityScale = 1;
                eventoAconteceu=true;
        }
    }
	}

}
