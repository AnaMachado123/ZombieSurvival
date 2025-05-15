using UnityEngine;

public class FundoLoopTriplo : MonoBehaviour
{
    public float velocidade = 2f;
    public Transform[] fundos; 

    private float largura;

    void Start()
    {
       
        SpriteRenderer sr = fundos[0].GetComponent<SpriteRenderer>();
        largura = sr.sprite.bounds.size.x * fundos[0].localScale.x;
    }

    void LateUpdate()
    {
        
        foreach (Transform fundo in fundos)
        {
            fundo.position += Vector3.left * velocidade * Time.deltaTime;
        }

        
        foreach (Transform fundo in fundos)
        {
            if (fundo.position.x <= -largura * 1.5f)
            {
                Transform maisADireita = fundo;

                
                foreach (Transform f in fundos)
                {
                    if (f != fundo && f.position.x > maisADireita.position.x)
                    {
                        maisADireita = f;
                    }
                }

                
                fundo.position = new Vector3(
                    maisADireita.position.x + largura - 0.01f,
                    fundo.position.y,
                    fundo.position.z
                );
            }
        }
    }
}
