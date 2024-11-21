using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDano : MonoBehaviour
{
    public void DanoAoPlayer(){
        if (CanvasGameMng.Instance.fimDoTempo == true) return;
        //Sortear a direção para expelir o jogador
        System.Random random = new System.Random();
        int valorSorteado = random.Next(0,2);
        int x = valorSorteado == 0 ? -1000 : 1000;
        PlayerMng.animacaoPlayer.PlayDamagePlayer();
        AudioMng.Instance.PlayAudioDanos();
        PlayerMng.Instance.ResetarVelocidadeDaFisica();
        PlayerMng.Instance.ArremessarPlayer(x,1000);
        
        //Decrementar a vida do player...
        CanvasGameMng.Instance.DecrementarVidaJogador();
    }
}
