using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCorpoPlayer : MonoBehaviour
{
    //Variável com as variáveis do SpriteRenderer
    private SpriteRenderer spriteCorpo;
    // Start is called before the first frame update
    void Start()
    {
        spriteCorpo = GetComponent<SpriteRenderer>();
    }

    public void OlharDireita(){
        spriteCorpo.flipX = false;
    }

    public void OlharEsquerda(){
        spriteCorpo.flipX = true;
    }
}
