using UnityEngine;

public class ColetarChave : MonoBehaviour
{
    private bool coletouChave = false;
    private void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.gameObject.tag == "Player" && coletouChave == false){
            coletouChave = true;
            PlayerMng.Instance.IncrementarChave();
            AudioMng.Instance.PlayAudioChave();
            Destroy(gameObject);
        }
    }
}