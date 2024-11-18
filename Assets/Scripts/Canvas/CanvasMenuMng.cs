using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMenuMng : MonoBehaviour
{
    public static CanvasMenuMng Instance;
    void Awake(){
        if(Instance == null){
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public TextMeshProUGUI[] txtsQtdItensColetadosDosNiveis;
    public GameObject[] cadeados;
    public GameObject[] qtdsItemLevel;
    public GameObject[] medalhas;

    public Sprite[] sptsMedalhas;

    public GameObject[] paineis;

    public Slider volumeVFX;
    public Slider volumeMusica;

    private Volume volumes;
    // Start is called before the first frame update
    void Start()
    {
        ConfigurarPainelNiveis();
        ConfigurarPainelConfiguracao();
        ExibirPainel(0);
    }

    public void ExibirPainel(int id)
    {
        foreach (var painel in paineis) 
        { 
            painel.SetActive(false);
        }
        paineis[id].SetActive(true);
    }

    public void FecharJogo()
    {
        Application.Quit();
    }

    private void ConfigurarPainelConfiguracao()
    {
        volumes = DBMng.ObterVolumes();
        volumeVFX.value = volumes.vfx;
        volumeMusica.value = volumes.musica;
        AudioMng.Instance.MudarVolume(volumes);
    }

    private void ConfigurarPainelNiveis()
    {
        for (int i = 1; i < txtsQtdItensColetadosDosNiveis.Length; i++)
        {
            txtsQtdItensColetadosDosNiveis[i].text = "x" + DBMng.BuscarQtdFrutasLevel(i).ToString();
        }

        for (int i = 2; i < cadeados.Length; i++)
        {
            bool estaHabilitado = DBMng.BuscarLevelHabilitado(i) == 1 ? true : false;
            cadeados[i].SetActive(!estaHabilitado);
            qtdsItemLevel[i].SetActive(estaHabilitado);
        }

        for (int i = 1; i < medalhas.Length; i++)
        {
            int medalhaDoLevel = DBMng.BuscarMedalhaLevel(i);
            if (medalhaDoLevel == 0)
            {
                medalhas[i].SetActive(false);
            }
            else
            {
                medalhas[i].GetComponent<Image>().sprite = sptsMedalhas[medalhaDoLevel];
            }
        }
    }

    public void IniciaLevel1(){
        SceneManager.LoadScene(1);
    }
    public void IniciarLevel(int idLevel){
        if(cadeados[idLevel].activeSelf == false){
            SceneManager.LoadScene(idLevel);
        }        
    }

    public void MudarVolumeVFX()
    {
        DBMng.SalvarVolume(volumeVFX.value, volumes.musica);
        AtualizarVolumes();
    }

    public void MudarVolumeMusica()
    {
        DBMng.SalvarVolume(volumes.vfx, volumeMusica.value);
        AtualizarVolumes();
    }

    private void AtualizarVolumes()
    {
        volumes = DBMng.ObterVolumes();
        AudioMng.Instance.MudarVolume(volumes);
    }
}
