using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarPlayer : MonoBehaviour
{
    //Variável de velocidade de movimento
    public float velocidade;
    //Variável com o script do Flip do corpo do player
    private FlipCorpoPlayer flipCorpoPlayer;
    //Variável com o script do Pé Player
    private PePlayer pePlayer;
    //Variável com o script da Cabeça do Player
    private CabecaPlayer cabecaPlayer;
    //Variáveis com os limites da esquerda e direita do Player
    private DireitaPlayer direitaPlayer;
    private EsquerdaPlayer esquerdaPlayer;

    //Variáveis para dar força ao jogador para pular
    public float forcaDoPuloY = 1.5f;
    public float forcaDoPuloX = 0;

    //Variável para verificar se o jogador está pulando
    public bool estaPulando;
    //Variável para habilitar o pulo duplo
    public bool puloDuplo;

    //Variável do rigidbody2D
    private Rigidbody2D rigidbody2D;

    //Uma variável de Coroutine
    private Coroutine coroutinePulo;

    private AnimacaoPlayer animacaoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        flipCorpoPlayer = GetComponentInChildren<FlipCorpoPlayer>();
        pePlayer = GetComponentInChildren<PePlayer>();
        cabecaPlayer = GetComponentInChildren<CabecaPlayer>();
        direitaPlayer = GetComponentInChildren<DireitaPlayer>();
        esquerdaPlayer = GetComponentInChildren<EsquerdaPlayer>();
        animacaoPlayer = GetComponentInChildren<AnimacaoPlayer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentar();
        Pular();
        PularDaParede();
    }

    //Método para pular o jogador
    private void Pular(){
        //Verificar se o jogador clicou na tecla para pular
        if(Input.GetButtonDown("Jump")){
            //Verificar se o jogador está no chão
            if(pePlayer.EstaNoChao == true){
                //Ativo o pulo
                animacaoPlayer.PlayJump();
                estaPulando = true;
                puloDuplo = true;
                AtivarCoroutinePulo();
            }
            else {
                //posso fazer um pulo duplo
                if(puloDuplo == true){
                    animacaoPlayer.PlayDoubleJump();
                    estaPulando = true;
                    puloDuplo = false;
                    AtivarCoroutinePulo();
                }                
            }
        }
    	
        //Verificar se está habilitado a pular
        if(estaPulando == true){
            //Verificar se a cabeça do jogador está livre
            if(cabecaPlayer.LimiteDaCabeca == false){
                //Fazer o jogador subir para simular o pulo
                rigidbody2D.velocity = Vector3.zero;
                rigidbody2D.gravityScale = 0;
                Vector3 direcaoPulo = new Vector3(forcaDoPuloX,forcaDoPuloY,0);
                transform.position += direcaoPulo * Time.deltaTime * velocidade;
            }            
        }
        else{
            rigidbody2D.gravityScale = 4;
        }
    }

    //Ativa a coroutina para finalizar o pulo
    private void AtivarCoroutinePulo(){
        if(coroutinePulo != null){
            StopCoroutine(coroutinePulo);
        }
        coroutinePulo = StartCoroutine(TempoPulo());
    }

    //Método para inverter o valor do está pulando atráves de um tempo
    private IEnumerator TempoPulo(){
        yield return new WaitForSeconds(0.3f);
        forcaDoPuloX = 0;
        estaPulando = false;
    }

    //Método para movimentar o jogador
    private void Movimentar(){
        //Obter a entrada do usuário, um teclado de início.
        float eixoX = Input.GetAxis("Horizontal");

        if(eixoX > 0 && direitaPlayer.LimiteDireita == true) {eixoX = 0;}
        else if(eixoX < 0 && esquerdaPlayer.LimiteEsquerda == true) { eixoX = 0; }

        //Verificar qual posição o player vai andar
        if(eixoX > 0){
            flipCorpoPlayer.OlharDireita();
        }
        else if(eixoX < 0){
            flipCorpoPlayer.OlharEsquerda();
        }

        //Verificar se o player está no chão
        if(pePlayer.EstaNoChao == true){
            //Verificar se o player está se movendo
            if(eixoX != 0){
                animacaoPlayer.PlayRun();
            }
            else{
                animacaoPlayer.PlayIdle();
            }
        }
        else{
            //Ativa animação de queda
            animacaoPlayer.PlayFall();
        }

        //Declarar uma variável para armazenar a direção do movimento do jogador
        Vector3 direcaoMovimento = new Vector3(eixoX,0,0);
        //Mover o objeto
        transform.position += direcaoMovimento * Time.deltaTime * velocidade;
    }

    private void PularDaParede(){
        //Verificar se o jogador não está no chão e se ele está em uma das paredes
        if(pePlayer.EstaNoChao == false && (direitaPlayer.LimiteDireita == true || esquerdaPlayer.LimiteEsquerda == true)){
            //Animação do pulo da parede
            animacaoPlayer.PlayWallSlider();
            //Verificar se o jogador clicou em pular
            if(Input.GetButtonDown("Jump")){
                forcaDoPuloX = flipCorpoPlayer.VisaoEsquerdaOuDireita == true ? forcaDoPuloY : forcaDoPuloY * -1;
                animacaoPlayer.PlayJump();
                puloDuplo = true;
                estaPulando = true;
                AtivarCoroutinePulo();
            }
        }
    }
}
