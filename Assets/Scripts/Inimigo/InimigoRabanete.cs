using UnityEngine;

public class InimigoRabanete : MonoBehaviour
{
    private SpriteRenderer corpo;
    private Animator animator;
    public float velocidade;
    private bool estaParado = false;
    private bool houveColisao = false;
    private string animacaoAtual;
    private float tempoDeEspera = 3;
    private float proximoTempo = 0;

    void Start()
    {
        corpo = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animacaoAtual = "run";
    }

    void Update()
    {
        if(estaParado == true){
            if(Time.time > proximoTempo){
                VirarInimigo();
            }
            return;
        }
        transform.Translate(Vector3.left * Time.deltaTime * velocidade);
    }

    private void OnTriggerExit2D(Collider2D colisao){
        if(colisao.gameObject.layer == 6){
            animator.SetTrigger("idle");
            animacaoAtual = "idle";
            proximoTempo = Time.time + tempoDeEspera;
            estaParado = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.layer == 10 && houveColisao == false){
            HitEnemy();
        }
    }
    private void OnTriggerStay2D(Collider2D colisao){
        if(colisao.gameObject.layer == 10 && houveColisao == false){
            HitEnemy();
        }
    }

    private void HitEnemy(){
        AudioMng.Instance.PlayAudioDanoInimigo();
        PlayerMng.playerDano.DanoAoPlayer();
        animator.SetTrigger("hit");
        houveColisao = true;
    }

    public void AtivaAnimacaoAposDano(){
        animator.SetTrigger(animacaoAtual);
        houveColisao = false;
    }

    private void VirarInimigo(){
        velocidade *= -1;
        corpo.flipX = !corpo.flipX;
        estaParado = false;
        animator.SetTrigger("run");
        animacaoAtual = "run";
        houveColisao = false;
    }
}