using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 7f;
    public int maxPulosExtras = 1;

    public Sprite spriteVitoria;

    private int pulosRestantes;
    private bool estaNoChao = false;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        pulosRestantes = maxPulosExtras;
    }

    void Update()
    {
        float movimento = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(movimento * velocidade, rb.linearVelocity.y);

        animator.SetBool("isRunning", Mathf.Abs(movimento) > 0.1f);

        if (movimento != 0)
            transform.localScale = new Vector3(Mathf.Sign(movimento), 1, 1);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (estaNoChao)
            {
                Pular();
            }
            else if (pulosRestantes > 0)
            {
                Pular();
                pulosRestantes--;
            }
        }
    }

    void Pular()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        animator.SetBool("isJumping", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            estaNoChao = true;
            pulosRestantes = maxPulosExtras;
            animator.SetBool("isJumping", false);
        }

        if (collision.gameObject.CompareTag("Zombie"))
        {
            animator.SetTrigger("Die");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            estaNoChao = false;
        }
    }

    public void Morrer()
    {
        animator.SetTrigger("Die");
        this.enabled = false;
        Object.FindFirstObjectByType<MenuController>()?.MostrarGameOver();
    }

    public void MostrarVitoriaVisual()
    {
        if (spriteRenderer != null && spriteVitoria != null)
        {
            animator.enabled = false;
            spriteRenderer.sprite = spriteVitoria;
        }
    }

    public bool EstaNoChao()
    {
        return estaNoChao;
    }

    public bool EstaACair()
    {
        return rb.linearVelocity.y < -0.1f;
    }
}
