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
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i< txtsQtdItensColetadosDosNiveis.Length;i++){
            txtsQtdItensColetadosDosNiveis[i].text = "x"+DBMng.BuscarQtdFrutasLevel(i).ToString();
        }

        for(int i = 2; i<cadeados.Length;i++){
            bool estaHabilitado = DBMng.BuscarLevelHabilitado(i) == 1 ? true : false;
            cadeados[i].SetActive(!estaHabilitado);
            qtdsItemLevel[i].SetActive(estaHabilitado);
        }

        for(int i = 1; i< medalhas.Length; i++){
            int medalhaDoLevel = DBMng.BuscarMedalhaLevel(i);
            if(medalhaDoLevel == 0){
                medalhas[i].SetActive(false);
            }
            else{
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
}
