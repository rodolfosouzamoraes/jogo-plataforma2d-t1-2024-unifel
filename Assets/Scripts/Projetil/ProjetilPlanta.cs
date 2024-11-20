using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilPlanta : MonoBehaviour
{
    public float velocidade;
    private Vector3 direcao;
    private bool houveColisao = false;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }

    public void MudarDirecao(Vector3 novaDirecao){
        direcao = novaDirecao;
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.layer == 10 && houveColisao == false){
            PlayerMng.playerDano.DanoAoPlayer();
            houveColisao = true;
        }
        Destroy(gameObject);
    }
}
