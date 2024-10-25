using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Desafio : MonoBehaviour
{

    public GameObject Protege;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      private void OnCollisionEnter2D(Collision2D other)
   {
        
        if(other.gameObject.CompareTag ("Player"))
        {
           // FindObjectOfType<GameObject>().DiminuirQuantidadeDeBlocos();
            //nstantiate(somDoBloco, transform.position, transform.rotation);
            
             
             Protege.SetActive (false);
 
           
        }
     }
}
