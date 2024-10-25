using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoTriggerControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log("bateu");
		if (collision.CompareTag("Player"))
        {
            GameObject coco = GameObject.Find("CocoSprite");
            coco.GetComponent<CocoController>().ativarGravidade();
			Debug.Log("achou");
		}
	}

}
