using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeEspinhos : MonoBehaviour
{
    public float velocidade = 100;
    public bool rotacaoConstante = false;

    // Update is called once per frame
    void Update()
    {
        //Rotatocionar o objeto
        transform.eulerAngles += Vector3.back * velocidade * Time.deltaTime;
        //Verificar se vou rotacionar constantemente ou intercalado
        if(transform.eulerAngles.z <=270 && 
        transform.eulerAngles.z >=90 && 
        rotacaoConstante == false){
            velocidade *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag == "Player"){
            CanvasGameMng.Instance.MatarJogador();
        }
    }
}
