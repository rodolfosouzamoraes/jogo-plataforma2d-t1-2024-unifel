using UnityEngine;

public class InicioDoLevel : MonoBehaviour
{
    public GameObject posicaoInicialPlayer;
    void Start()
    {
        PlayerMng.Instance.gameObject.transform.position = posicaoInicialPlayer.transform.position;
        AudioMng.Instance.PlayAudioSurgir();
    }
}