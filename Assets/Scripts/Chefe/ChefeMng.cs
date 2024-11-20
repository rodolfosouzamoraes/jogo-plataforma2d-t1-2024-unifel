using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ChefeMng : MonoBehaviour
{
    private Animator animator;
    private int vidaChefe = 4;
    private List<BoxCollider2D> colisoes;
    public GameObject elementosLevel;
    public bool estaMovendo = false;

    
    // Start is called before the first frame update
    void Start()
    {
        elementosLevel.SetActive(false);
        animator = GetComponent<Animator>();
        colisoes = GetComponentsInChildren<BoxCollider2D>().ToList();
        colisoes.Add(GetComponent<BoxCollider2D>());
    }

    public void DecrementarVidaChefe()
    {
        vidaChefe--;
        
        if (vidaChefe == 0)
        {
            estaMovendo = false;
            foreach (var colisao in colisoes)
            {
                Destroy(colisao);
            }
            animator.SetTrigger("death");
            AudioMng.Instance.PlayAudioMorteChefe();
        }
        else
        {
            PlayHit();
        }
    }

    public void HabilitaMovimentacao()
    {
        estaMovendo = true;
        PlayRun();
    }

    public void PlayRun()
    {
        animator.SetBool("run", true);
        animator.SetBool("idle", false);
    }

    public void PlayHit()
    {
        animator.SetTrigger("hit");
    }

    public void EnableFinalLevel()
    {
        elementosLevel.SetActive(true);
        Destroy(gameObject);
    }
}
