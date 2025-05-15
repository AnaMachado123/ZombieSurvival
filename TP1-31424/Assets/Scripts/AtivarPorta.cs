using UnityEngine;

public class AtivarPorta : MonoBehaviour
{
    public GameObject porta;
    public float tempoParaAparecer = 20f;

    private float cronometro = 0f;
    private bool ativada = false;

    void Update()
    {
        if (!ativada)
        {
            cronometro += Time.deltaTime;

            if (cronometro >= tempoParaAparecer)
            {
                porta.SetActive(true);
                ativada = true;
                
            }
        }
    }
}
