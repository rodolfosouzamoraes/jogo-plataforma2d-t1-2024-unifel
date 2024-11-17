using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContatoPlataformaFlutuante : MonoBehaviour
{
    private SpriteRenderer corpo;
    private bool saiuDaColisao = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        corpo = GetComponentInParent<SpriteRenderer>();
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerExit2D(Collider2D colisao){
        if(colisao.gameObject.tag.Equals("PePlayer") && saiuDaColisao == false){
            var rigidbody = corpo.gameObject.AddComponent<Rigidbody2D>();
            rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            saiuDaColisao = true;
            animator.SetTrigger("death");
            Destroy(corpo.gameObject,0.25f);
        }
    }
}
