using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carregando : MonoBehaviour
{
    public Button T1;
    public Button T2;
    public Button T3;
    public Button T4;
    public Button T5;
    public Button T6;
    public Button T7;
    public Button T8;
    public Button T9;
    public Button T10;
    public Button T11;
    public Button T12;
    public Button T13;


    public Button H1;
    public Button H2;
    public Button H3;
    public Button H4;
    public Button H5;
    public Button H6;
    public Button H7;
    public Button H8;
    public Button HBonus;
    public Button Hfechar;

    


     public GameObject B1;
      public GameObject B2;
       public GameObject Seta;


       public GameObject VoltaHome;
    

    

    public Button Voltar;
    public Button Informacao;
    


    public GameObject Loading;
    
    // Start is called before the first frame update

    // Update is called once per frame
    public void Load() 

    {
     Loading.SetActive (true);
    
    T1.interactable = false;
    T2.interactable = false;
    T3.interactable = false;
    T4.interactable = false;
    T5.interactable = false;
    T6.interactable = false;
    T7.interactable = false;
    T8.interactable = false;
    T9.interactable = false;
    T10.interactable = false;
    T11.interactable = false;
    T12.interactable = false;
    T13.interactable = false;

    H1.interactable = false;
    H2.interactable = false;
    H3.interactable = false;
    H4.interactable = false;
    H5.interactable = false;
    H6.interactable = false;
    H7.interactable = false;
    H8.interactable = false;
    HBonus.interactable = false;
    Hfechar.interactable = false;

    


    Voltar.interactable = false;
    Informacao.interactable = false;
    VoltaHome.SetActive  (false);

    B1.SetActive (false);
    B2.SetActive (false);
    Seta.SetActive (false);




}
}
