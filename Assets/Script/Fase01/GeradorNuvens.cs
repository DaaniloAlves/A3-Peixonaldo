using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorNuvens : MonoBehaviour
{

    [SerializeField] private GameObject[] nuvens;
    private float intervaloGeracao = 2.5f;
    [SerializeField] private bool destruidor = false; // verificando se o gameobject deve ser o destruidor ou o gerador

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!destruidor)
        {
            gerarNuvem();
        }
    }

    private void gerarNuvem()
    {
        if (!isInIntervalo())
        {
            int choice = Random.Range(1, 3);
			float posicao = Random.Range(1.65f, 4.66f);
            switch (choice)
            {
                case 1:
                    GameObject nuvem = Instantiate(nuvens[0], new Vector3(transform.position.x, posicao, transform.position.z), Quaternion.identity);
                    break;
                case 2:
					GameObject nuvem1 = Instantiate(nuvens[1], new Vector3(transform.position.x, posicao, transform.position.z), Quaternion.identity);
					break;
                default:
                    break;
            }
        }
    }

    private bool isInIntervalo()
    {
        if (intervaloGeracao > 0)
        {
            intervaloGeracao -= Time.deltaTime;
            return true;
        } 
        intervaloGeracao = Random.Range(3, 5f);
        return false;
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(collision.gameObject);
	}


}
