using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPassaroAzul : MonoBehaviour
{
    private SpriteRenderer sptCorpo;
    public float distanciaDeMovimento;
    public float velocidadeDeMovimento;
    private Vector3 posicaoInicial;
    private Vector3 posicaoFinal;
    private Vector3 posicaoAlvo;
    private Animator animator;
    private bool estaMorto = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sptCorpo = GetComponent<SpriteRenderer>();
        posicaoInicial = transform.position;
        posicaoAlvo = posicaoFinal = transform.position + new Vector3(distanciaDeMovimento,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicaoAlvo, Time.deltaTime * velocidadeDeMovimento);
        if(Vector3.Distance(transform.position, posicaoAlvo) < 0.001f){
            if(sptCorpo.flipX == false){
                posicaoAlvo = posicaoInicial;
                sptCorpo.flipX = true;
            }
            else{
                posicaoAlvo = posicaoFinal;
                sptCorpo.flipX = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag.Equals("Player") && estaMorto == false){
            AudioMng.Instance.PlayAudioDanoInimigo();
            PlayerMng.Instance.ExpelirPlayer();
            animator.SetTrigger("morte");
            estaMorto = true;
        }
    }

    public void DestruirInimigo(){
        Destroy(gameObject);
    }
}
