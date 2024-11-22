using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoPlayer : MonoBehaviour
{
    //Variável com os scripts do Animator
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //Iniciar a animação do personagem parado
    public void PlayIdle(){
        animator.SetBool("idle",true);
        animator.SetBool("jump",false);
        animator.SetBool("run",false);
        animator.SetBool("fall",false);
        animator.SetBool("wallSlider", false);
    }

    public void PlayRun(){
        animator.SetBool("idle",false);
        animator.SetBool("jump",false);
        animator.SetBool("run",true);
        animator.SetBool("fall",false);
        animator.SetBool("wallSlider", false);
    }

    public void PlayJump(){
        animator.SetBool("idle",false);
        animator.SetBool("jump",true);
        animator.SetBool("run",false);
        animator.SetBool("fall",false);
        animator.SetBool("wallSlider", false);
    }

    public void PlayFall(){
        animator.SetBool("idle",false);
        animator.SetBool("jump",false);
        animator.SetBool("run",false);
        animator.SetBool("fall",true);
        animator.SetBool("wallSlider", false);
    }

    public void PlayDoubleJump(){
        animator.SetBool("idle",false);
        animator.SetBool("jump",false);
        animator.SetBool("run",false);
        animator.SetBool("fall",false);
        animator.SetBool("wallSlider", false);
        animator.SetTrigger("doubleJump");
    }

    public void PlayWallSlider(){
        animator.SetBool("idle",false);
        animator.SetBool("jump",false);
        animator.SetBool("run",false);
        animator.SetBool("fall",false);
        animator.SetBool("wallSlider", true);
    }

    public void PlayDamagePlayer(){
        animator.SetTrigger("damage");
    }

    public void PlayDeathPlayer(){
        animator.SetTrigger("death");
    }

    public void HabilitarMovimentacaoDoJogador(){
        PlayerMng.Instance.HabilitarMovimentacao();
    }

    public void PlayAudioMovimentacao(){
        AudioMng.Instance.PlayAudioCorrer();
    }
}
