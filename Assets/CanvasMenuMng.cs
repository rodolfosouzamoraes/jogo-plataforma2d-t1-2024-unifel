using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    
    public void IniciarLevel(int idLevel){
        if(cadeados[idLevel].activeSelf == false){
            SceneManager.LoadScene(idLevel);
        }        
    }
}
