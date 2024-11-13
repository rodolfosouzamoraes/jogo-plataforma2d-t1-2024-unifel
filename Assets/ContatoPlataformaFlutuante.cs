using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContatoPlataformaFlutuante : MonoBehaviour
{
    private SpriteRenderer corpo;
    private bool saiuDaColisao = false;
    // Start is called before the first frame update
    void Start()
    {
        corpo = GetComponentInParent<SpriteRenderer>();
    }


    private void OnTriggerExit2D(Collider2D colisao)
    {
        if (colisao.gameObject.tag.Equals("Player") && saiuDaColisao == false)
        {
            var rigibody = corpo.gameObject.AddComponent<Rigidbody2D>();
            rigibody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            saiuDaColisao = true;
            Destroy(corpo.gameObject,0.5f);
        }
    }
}
