using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Header("Configuração de movimento")]
    [Tooltip("Velocidade com que o zombie se move para a esquerda")]
    public float velocidade = 2f;

    void Update()
    {
        
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);
    }
}
