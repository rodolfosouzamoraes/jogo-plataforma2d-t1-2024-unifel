using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilhaLamina : MonoBehaviour
{
    public Vector3[] caminhos;
    public float velocidade;
    private int idCaminho;

    public float tempoDeEspera;
    private bool proximoCaminho = false;
    private float proximoTempoDeEspera = 0;
    private bool houveColisao = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = caminhos[0];
        idCaminho = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //verificando se eu posso ir para o próximo caminho
        if(proximoCaminho == true){
            //Lógica para ir para o próximo caminho
            if(Time.time > proximoTempoDeEspera){
                idCaminho++;
                if(idCaminho == caminhos.Length){
                    idCaminho = 0;
                }
                proximoCaminho = false;
            }
        }
        else{
            //Movimentar o objeto até o caminho selecionado
            float velocidadeMovimento = velocidade * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, 
            caminhos[idCaminho],velocidadeMovimento);
            if(Vector3.Distance(transform.position, caminhos[idCaminho]) < 0.001f){
                proximoTempoDeEspera = Time.time + tempoDeEspera;
                proximoCaminho = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag.Equals("Player") && houveColisao == false){
            CanvasGameMng.Instance.MatarJogador();
            houveColisao = true;
        }
    }
}
