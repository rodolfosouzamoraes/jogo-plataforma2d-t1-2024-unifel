using System.Collections;
using UnityEngine;

public class DanoChefe : MonoBehaviour
{
    private ChefeMng chefeMng;
    private bool houveColisao = false;

    void Start()
    {
        chefeMng = GetComponentInParent<ChefeMng>();
    }

    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag == "PePlayer" && houveColisao == false){
            houveColisao = true;
            PlayerMng.Instance.ExpelirPlayer();
            AudioMng.Instance.PlayAudioDanoInimigo();
            chefeMng.DecrementarVidaChefe();
            StartCoroutine(PermitirColisao());
        }
    }

    IEnumerator PermitirColisao(){
        yield return new WaitForSeconds(0.3f);
        houveColisao = false;
    }
}