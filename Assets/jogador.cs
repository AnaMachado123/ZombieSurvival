using UnityEngine;
using System.Collections;

public class Jogador : MonoBehaviour
{
    public float velocidade = 2f;
    public float forcaPulo = 6f;
    public float forcaPuloExtra = 12f;
    public float tempoPuloExtra = 0.2f;
    public Animator animacao;
    public GameObject painelGameOver;

    private Rigidbody2D corpo;
    private SpriteRenderer visual;
    private bool noChao;
    private float tempoPulando;
    private bool morreu = false;

    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
        visual = GetComponent<SpriteRenderer>();
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (morreu) return; 

        float mover = Input.GetAxisRaw("Horizontal");
        corpo.linearVelocity = new Vector2(mover * velocidade, corpo.linearVelocity.y);

        // Salto
        if (Input.GetKeyDown(KeyCode.UpArrow) && noChao)
        {
            corpo.linearVelocity = new Vector2(corpo.linearVelocity.x, forcaPulo);
            tempoPulando = tempoPuloExtra;
            animacao.Play("saltar");
        }

        if (Input.GetKey(KeyCode.UpArrow) && tempoPulando > 0)
        {
            corpo.linearVelocity = new Vector2(corpo.linearVelocity.x, forcaPuloExtra);
            tempoPulando -= Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            tempoPulando = 0;
        }

    
        if (mover != 0)
            animacao.Play("andar");
        else
            animacao.Play("parar");

        if (mover != 0)
            visual.flipX = mover > 0;

        float limiteEsquerda = -11f;
        float limiteDireita = 11f;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, limiteEsquerda, limiteDireita),
            transform.position.y,
            transform.position.z
        );
    }

   void OnTriggerEnter2D(Collider2D col)
    {
    if (col.CompareTag("alvo") && noChao && !morreu)
    {
        StartCoroutine(GameOverAnimado());
    }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        noChao = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        noChao = false;
    }

    IEnumerator GameOverAnimado()
    {
        morreu = true;
        animacao.Play("morrer");

        yield return new WaitForSeconds(1f);

        Time.timeScale = 0f;
        if (painelGameOver != null)
            painelGameOver.SetActive(true);
    }
}
