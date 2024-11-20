using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemColetavel : MonoBehaviour
{
    private Animator animator;
    private bool coletouItem = false;

    void Start(){
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag.Equals("Player") && coletouItem == false){
            AudioMng.Instance.PlayAudioFruta();
            animator.SetTrigger("coletarItem");
            coletouItem = true;
            
            //Incrementar a coleta no jogo
            CanvasGameMng.Instance.IncrementarItemColetavel();
        }
    }

    private void DestruirColetavel(){
        Destroy(gameObject);
    }
}
