using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDoJogo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.layer == 10 && CanvasGameMng.Instance.jogadorMorreu == false){
            CanvasGameMng.Instance.MatarJogador();
        }
    }
}
