using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float velocidade = 2f;
    private Animator animador;
    private bool podeMover = true;

    void Start()
    {
        animador = GetComponent<Animator>();

        if (animador != null)
        {
            animador.Play("Attack"); 
        }
    }

    void Update()
    {
        if (!podeMover) return;

        
        transform.position += Vector3.left * velocidade * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D colisao)
{
    if (colisao.CompareTag("Player"))
    {
        Jogador jogador = colisao.GetComponent<Jogador>();

        if (jogador != null)
        {
            bool estaNoChao = jogador.EstaNoChao();
            bool estaACair = jogador.EstaACair();

           
            if (estaNoChao && !estaACair)
            
                jogador.Morrer();
               
    
        }
    }
  }
}