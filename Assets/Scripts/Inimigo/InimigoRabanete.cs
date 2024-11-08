using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoRabanete : MonoBehaviour
{
    private SpriteRenderer corpo;
    private Animator animator;
    public float velocidade;
    private bool estaParado = false;
    private bool houveColisao = false;
    private Coroutine rotinaFlip;
    private string animacaoAtual;

    // Start is called before the first frame update
    void Start()
    {
        corpo = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animacaoAtual = "run";
    }

    // Update is called once per frame
    void Update()
    {
        if(estaParado == true) return;
        transform.Translate(Vector3.left * Time.deltaTime * velocidade);
    }

    private void OnTriggerExit2D(Collider2D colisao){
        if(colisao.gameObject.layer == 6){
            animator.SetTrigger("idle");
            animacaoAtual = "idle";
            estaParado = true;
            if(rotinaFlip != null){
                StopCoroutine(rotinaFlip);
            }
            rotinaFlip = StartCoroutine(AguardarParaVirarEMovimentar());
        }
    }

    IEnumerator AguardarParaVirarEMovimentar(){
        yield return new WaitForSeconds(3f);
        velocidade *= -1;
        corpo.flipX = !corpo.flipX;
        estaParado = false;
        animator.SetTrigger("run");
        animacaoAtual = "run";
        houveColisao = false;
    }
}
