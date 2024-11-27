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

    void Start()
    {
        transform.position = caminhos[0];
        idCaminho = 1;
    }

    void Update()
    {
        if(proximoCaminho == true){
            if(Time.time > proximoTempoDeEspera){
                idCaminho++;
                if(idCaminho == caminhos.Length){
                    idCaminho = 0;
                }
                proximoCaminho = false;
            }
        }
        else{
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