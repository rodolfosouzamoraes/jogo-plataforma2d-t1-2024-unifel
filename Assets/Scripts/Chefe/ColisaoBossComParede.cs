using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoBossComParede : MonoBehaviour
{
    private MovimentarChefe movimentarChefe;
    private bool houveColisao = false;
    private void Start()
    {
        movimentarChefe = GetComponentInParent<MovimentarChefe>();
    }
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.layer == 6 && houveColisao == false)
        {
            houveColisao = true;
            movimentarChefe.FlipCorpo();
        }
    }

    private void OnTriggerExit2D(Collider2D colisao)
    {
        if(colisao.gameObject.layer == 6)
        {
            houveColisao = false;
        }
    }
}
