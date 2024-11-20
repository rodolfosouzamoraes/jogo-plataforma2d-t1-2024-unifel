using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecharPortao : MonoBehaviour
{
    private bool fecharPortao = false;
    private Quaternion rotacaoAlvo;
    public float velocidade;
    public GameObject fechadura;
    public GameObject grade;
    // Start is called before the first frame update
    void Start()
    {
        rotacaoAlvo = Quaternion.Euler(new Vector3(0,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        if(fecharPortao == true){
            grade.transform.rotation = Quaternion.RotateTowards(grade.transform.rotation,
            rotacaoAlvo, velocidade * Time.deltaTime);
        }
    }

    private void OnTriggerExit2D(Collider2D colisao){
        if(colisao.gameObject.layer == 10 && fecharPortao == false){
            fecharPortao = true;
            GetComponent<BoxCollider2D>().isTrigger = false;
    	    Invoke("MudarLayer", 1.5f);
            Invoke("AtivarFechadura", 1f);
        }
    }

    private void AtivarFechadura(){
        fechadura.SetActive(true);
    }

    private void MudarLayer(){
        transform.gameObject.layer = 6;
    }
}
