using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMng : MonoBehaviour
{
    public static AudioMng Instance;

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

    public AudioSource audioVFX;
    public AudioSource audioMusica;

    public void MudarVolume(Volume volume)
    {
        audioVFX.volume = volume.vfx;
        audioMusica.volume = volume.musica;
    }
}
