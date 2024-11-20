using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecharPortao : MonoBehaviour
{
    private bool fechouPortao = false;
    private Quaternion rotacaoAlvo;
    public float velocidade;
    public GameObject fechadura;
    public GameObject corpo;
    // Start is called before the first frame update
    void Start()
    {
        rotacaoAlvo = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (fechouPortao == true)
        {
            corpo.transform.rotation = Quaternion.RotateTowards(corpo.transform.rotation,
            rotacaoAlvo, velocidade * Time.deltaTime);
        }
    }

    private void OnTriggerExit2D(Collider2D colisao)
    {
        if (colisao.gameObject.tag.Equals("Player") && fechouPortao == false)
        {
            fechouPortao = true;
            GetComponent<BoxCollider2D>().isTrigger = false;
            Invoke("MudarLayer", 1.5f);
            Invoke("AtivaFechadura", 1f);
        }
    }

    private void AtivaFechadura()
    {
        fechadura.SetActive(true);
        AudioMng.Instance.PlayAudioPortao();
    }

    private void MudarLayer()
    {
        transform.gameObject.layer = 6;
    }
}
