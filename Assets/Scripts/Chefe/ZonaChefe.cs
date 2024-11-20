using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaChefe : MonoBehaviour
{
    private ChefeMng chefeMng;

    private void Start()
    {
        chefeMng = FindObjectOfType<ChefeMng>();
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.layer == 10)
        {
            AudioMng.Instance.PlayAudioChefe();
            chefeMng.HabilitaMovimentacao();
            Destroy(gameObject);
        }
    }
}
