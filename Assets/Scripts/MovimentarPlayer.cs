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

    //Variável para dar força ao jogador para pular
    public float forcaDoPuloY = 1.5f;
    //Variável para verificar se o jogador está pulando
    public bool estaPulando;

    // Start is called before the first frame update
    void Start()
    {
        flipCorpoPlayer = GetComponentInChildren<FlipCorpoPlayer>();
        pePlayer = GetComponentInChildren<PePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentar();
        Pular();
    }

    //Método para pular o jogador
    private void Pular(){
        //Verificar se o jogador clicou na tecla para pular
        if(Input.GetButtonDown("Jump")){
            //Verificar se o jogador está no chão
            if(pePlayer.EstaNoChao == true){
                //Ativo o pulo
            }
            else {
                //posso fazer um pulo duplo
            }
        }
    }

    //Método para movimentar o jogador
    private void Movimentar(){
        //Obter a entrada do usuário, um teclado de início.
        float eixoX = Input.GetAxis("Horizontal");
        //Verificar qual posição o player vai andar
        if(eixoX > 0){
            flipCorpoPlayer.OlharDireita();
        }
        else if(eixoX < 0){
            flipCorpoPlayer.OlharEsquerda();
        }
        //Declarar uma variável para armazenar a direção do movimento do jogador
        Vector3 direcaoMovimento = new Vector3(eixoX,0,0);
        //Mover o objeto
        transform.position += direcaoMovimento * Time.deltaTime * velocidade;
    }
}
