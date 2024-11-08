using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
    public TextMeshProUGUI txtTotalItensColetados;
    public TextMeshProUGUI txtTotalItensFimDoJogo;
    public TextMeshProUGUI txtTempoDeJogo;
    public GameObject painelFimDoJogo;
    public Sprite[] sptsMedalhas;
    public Image imgMedalhaDoLevel;
    private int vidas; 
    private int totalItensColetados = 0;
    public float tempoDoLevel;
    private bool fimDoTempo;
    private int idLevel;
    private double qtdItensColetaveis;
    private int medalhaDoLevel;
    // Start is called before the first frame update
    void Start()
    {
        vidas = sptsBarraDeVida.Length -1;
        medalhaDoLevel = 0;
        fimDoTempo = false;
        idLevel = SceneManager.GetActiveScene().buildIndex;
        qtdItensColetaveis = FindObjectsOfType<ItemColetavel>().Length;
    }

    void Update(){
        ContarTempo();
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
        ReiniciarLevelAtual();
    }

    public void IncrementarItemColetavel(){
        totalItensColetados++;
        txtTotalItensColetados.text = $"x{totalItensColetados}";
    }

    public void ContarTempo(){
        if(fimDoTempo == true) return;

        tempoDoLevel -= Time.deltaTime;
        if(tempoDoLevel < 0){
            fimDoTempo = true;
            vidas = 0;
            DecrementarVidaJogador();
        }
        else{
            //Exibir o tempo na tela
            txtTempoDeJogo.text = ((int)tempoDoLevel).ToString();
        }
    }

    public void FimDeJogo(){
        fimDoTempo = true;
        PlayerMng.Instance.CongelarPlayer();
        SalvarDadosDoLevel();
        StartCoroutine(ExibirTelaFinalDoLevel());
    }

    private IEnumerator ExibirTelaFinalDoLevel(){
        yield return new WaitForSeconds(3f);
        painelFimDoJogo.SetActive(true);
        int contagem = 0;
        while(contagem < totalItensColetados){
            contagem++;
            txtTotalItensFimDoJogo.text = $"x{contagem}";
            yield return new WaitForSeconds(0.1f);
        }

    }

    private void SalvarDadosDoLevel(){
        int itensSalvosDoLevel = DBMng.BuscarQtdFrutasLevel(idLevel);
        DefinirMedalhaDoLevel();
        if(totalItensColetados>itensSalvosDoLevel){
            DBMng.SalvarDadosLevel(idLevel,totalItensColetados,medalhaDoLevel);
        }
    }

    public void VoltarParaMenu(){
        SceneManager.LoadScene(0);
    }

    public void ReiniciarLevelAtual(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ProximoLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    private void DefinirMedalhaDoLevel(){
        double porcentagemColetado = ((double)totalItensColetados/qtdItensColetaveis) * 100;
        if(porcentagemColetado<50){
            medalhaDoLevel = 1;
        }
        else if(porcentagemColetado >=50 && porcentagemColetado <100){
            medalhaDoLevel = 2;
        }
        else{
            medalhaDoLevel = 3;
        }
        imgMedalhaDoLevel.sprite = sptsMedalhas[medalhaDoLevel];
    }
}
