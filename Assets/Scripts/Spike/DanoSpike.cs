using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoSpike : MonoBehaviour
{
    bool houveColisao = false;
    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.layer == 10 && houveColisao == false){
            houveColisao = true;
            PlayerMng.playerDano.DanoAoPlayer();
            StartCoroutine(PermitirColisao());
        }
    }

    IEnumerator PermitirColisao(){
        yield return new WaitForSeconds(0.3f);
        houveColisao = false;
    }
}
