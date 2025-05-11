using UnityEngine;

public class fundoloop : MonoBehaviour
{
    public Transform fundo1;
    public Transform fundo2;
    public float velocidade = 2f;

    private float larguraFundo;

    void Start()
    {
        larguraFundo = fundo1.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        fundo1.position += Vector3.left * velocidade * Time.deltaTime;
        fundo2.position += Vector3.left * velocidade * Time.deltaTime;

        if (fundo1.position.x <= -larguraFundo)
            fundo1.position = new Vector3(fundo2.position.x + larguraFundo, fundo1.position.y, fundo1.position.z);

        if (fundo2.position.x <= -larguraFundo)
            fundo2.position = new Vector3(fundo1.position.x + larguraFundo, fundo2.position.y, fundo2.position.z);
    }
}
