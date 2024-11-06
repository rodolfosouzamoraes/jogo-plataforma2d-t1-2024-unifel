using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioDoLevel : MonoBehaviour
{
    public GameObject posicaoInicialPlayer;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMng.Instance.gameObject.transform.position = posicaoInicialPlayer.transform.position;
    }
}
