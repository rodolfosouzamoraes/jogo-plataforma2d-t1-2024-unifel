using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DireitaPlayer : MonoBehaviour
{
    private bool limiteDireita;

    public bool LimiteDireita{
        get {return limiteDireita;}
    }

    //Detecta se o objeto ainda está colidindo
    private void OnTriggerEnter2D(Collider2D colisor){
        if(colisor.gameObject.layer == 6){
            limiteDireita = true;
        }
    }
    //Detecta se o objeto parou de colidir
    private void OnTriggerExit2D(Collider2D colisor){
        if(colisor.gameObject.layer == 6){
            limiteDireita = false;
        }
    }
}
