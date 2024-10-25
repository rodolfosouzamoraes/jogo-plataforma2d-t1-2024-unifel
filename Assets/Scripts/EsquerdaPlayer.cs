using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsquerdaPlayer : MonoBehaviour
{
    private bool limiteEsquerda;

    public bool LimiteEsquerda{
        get {return limiteEsquerda;}
    }

    //Detecta se o objeto ainda está colidindo
    private void OnTriggerEnter2D(Collider2D colisor){
        if(colisor.gameObject.layer == 6){
            limiteEsquerda = true;
        }
    }
    //Detecta se o objeto parou de colidir
    private void OnTriggerExit2D(Collider2D colisor){
        if(colisor.gameObject.layer == 6){
            limiteEsquerda = false;
        }
    }
}
