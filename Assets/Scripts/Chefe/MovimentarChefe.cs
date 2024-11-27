using UnityEngine;

public class MovimentarChefe : MonoBehaviour
{
    public float velocidade;
    private SpriteRenderer corpo;
    private ChefeMng chefeMng;
    void Start()
    {
        corpo = GetComponent<SpriteRenderer>();
        chefeMng = GetComponent<ChefeMng>();
    }

    void Update()
    {
        if(chefeMng.estaMovendo == false) return;
        if(corpo.flipX == false){
            transform.Translate(Vector3.left * velocidade * Time.deltaTime);
        }
        else {
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);
        }
    }

    public void FlipCorpo(){
        corpo.flipX = !corpo.flipX;
    }
}