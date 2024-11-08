using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FimDoLevel : MonoBehaviour
{
    private Animator animator;
    private bool fimDoLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag.Equals("Player") && fimDoLevel == false){
            fimDoLevel = true;
            animator.SetTrigger("finished");
            CanvasGameMng.Instance.FimDeJogo();
        }
    }
}
