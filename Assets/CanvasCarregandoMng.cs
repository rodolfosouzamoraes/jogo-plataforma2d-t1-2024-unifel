using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCarregandoMng : MonoBehaviour
{
    public static CanvasCarregandoMng Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    public GameObject pnlCarregando;

    public void ExibirPainelCarregando()
    {
        pnlCarregando.SetActive(true);
    }

    public void OcultarPainelCarregando()
    {
        pnlCarregando.SetActive(false);
    }
}
