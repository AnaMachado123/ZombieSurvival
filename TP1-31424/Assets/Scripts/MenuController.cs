using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public GameObject menuInicial;
    public GameObject menuGameOver;
    public GameObject menuVitoria;

    void Start()
    {
        menuInicial.SetActive(true);
        menuGameOver.SetActive(false);
        menuVitoria.SetActive(false);
        Time.timeScale = 0f;
    }

    public void IniciarJogo()
    {
        menuInicial.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MostrarGameOver()
    {
        StartCoroutine(AbrirMenuGameOverComDelay());
    }

    public void MostrarVitoria()
    {
        StartCoroutine(AbrirMenuVitoriaComDelay());
    }

    private IEnumerator AbrirMenuGameOverComDelay()
    {
        yield return new WaitForSeconds(3f);
        menuGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    private IEnumerator AbrirMenuVitoriaComDelay()
    {
        yield return new WaitForSeconds(3f);
        menuVitoria.SetActive(true);
        Time.timeScale = 0f;
    }
}
