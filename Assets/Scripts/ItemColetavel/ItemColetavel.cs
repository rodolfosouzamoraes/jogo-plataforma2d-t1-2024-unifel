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
            animator.SetTrigger("coletarItem");
            AudioMng.Instance.PlayAudioFruta();
            coletouItem = true;
            CanvasGameMng.Instance.IncrementarItemColetavel();
        }
    }

    private void DestruirColetavel(){
        Destroy(gameObject);
    }
}