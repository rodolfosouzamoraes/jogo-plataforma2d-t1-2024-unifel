using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChefeMng : MonoBehaviour
{
    private Animator animator;//Variavel da animação
    private int vidaChefe = 4;
    private List<BoxCollider2D> colisores;//Lista de colisores do chefe
    public GameObject itemFinal;
    public bool estaMovendo = false;
    // Start is called before the first frame update
    void Start()
    {
        itemFinal.SetActive(false);
        animator = GetComponent<Animator>();
        colisores = GetComponentsInChildren<BoxCollider2D>().ToList();
        colisores.Add(GetComponent<BoxCollider2D>());
    }

    public void DecrementarVidaChefe(){
        vidaChefe--;
        if(vidaChefe == 0){
            estaMovendo = false;

            foreach(var colisor in colisores){
                Destroy(colisor);
            }

            animator.SetTrigger("death");
        }
        else{
            animator.SetTrigger("hit");
        }
    }

    public void HabilitaMovimentacao(){
        estaMovendo = true;
        animator.SetBool("run", true);
        animator.SetBool("idle", false);
    }

    public void AtivarItemFinal(){
        itemFinal.SetActive(true);
        Destroy(gameObject);
    }

}
