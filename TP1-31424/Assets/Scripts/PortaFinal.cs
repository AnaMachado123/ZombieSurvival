using UnityEngine;

public class PortaFinal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        Object.FindFirstObjectByType<MenuController>()?.MostrarVitoria();
        other.GetComponent<Jogador>()?.MostrarVitoriaVisual();
    }
}

}
