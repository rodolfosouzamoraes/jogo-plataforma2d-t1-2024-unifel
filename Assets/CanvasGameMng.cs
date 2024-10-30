using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasGameMng : MonoBehaviour
{
    public static CanvasGameMng Instance;

    void Awake(){
        if(Instance == null){
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public Sprite[] sptsBarraDeVida;
    public Image imgBarraDeVida;
    private int vidas; 
    // Start is called before the first frame update
    void Start()
    {
        vidas = sptsBarraDeVida.Length -1;
    }

    public void DecrementarVidaJogador(){
        vidas--;
        if(vidas < 0){
            PlayerMng.animacaoPlayer.PlayDeathPlayer();
            PlayerMng.Instance.DesabilitaMovimentacao();
            PlayerMng.Instance.RemoverSimulacaoDaFisica();
            StartCoroutine(ReiniciarLevel());
        }
        else{
            imgBarraDeVida.sprite = sptsBarraDeVida[vidas];
        }
    }

    IEnumerator ReiniciarLevel(){
        yield return new WaitForSeconds(3);
        //Game Over - vou reiniciar a cena do jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
