using UnityEngine;

public class FimDoLevel : MonoBehaviour
{
    private Animator animator;
    private bool fimDoLevel = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag.Equals("Player") && fimDoLevel == false){
            fimDoLevel = true;
            AudioMng.Instance.PlayAudioItemFinal();
            animator.SetTrigger("finished");
            CanvasGameMng.Instance.FimDeJogo();
        }
    }
}