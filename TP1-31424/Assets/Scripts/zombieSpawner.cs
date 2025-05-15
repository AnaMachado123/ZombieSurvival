using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform jogador;

    [Header("Intervalos de spawn")]
    public float intervaloMin = 1.5f;
    public float intervaloMax = 2.5f;

    [Header("Grupo de zombies")]
    public int minZombies = 2;
    public int maxZombies = 4;

    [Header("Distâncias")]
    public float distanciaInicial = 10f;
    public float distanciaEntreGrupos = 8f;
    public float espacamentoEntreZombies = 2f;
    public float ySpawn = -1.2f;

    [Header("Velocidade")]
    public float velocidadeMin = 2f;
    public float velocidadeMax = 4f;

    private float proximoSpawnX;

    void Start()
    {
        if (jogador != null)
            proximoSpawnX = jogador.position.x + distanciaInicial;

        Invoke("SpawnGrupo", Random.Range(intervaloMin, intervaloMax));
    }

    void SpawnGrupo()
    {
        if (zombiePrefab == null || jogador == null) return;

        int quantidade = Random.Range(minZombies, maxZombies + 1);

        for (int i = 0; i < quantidade; i++)
        {
            Vector3 pos = new Vector3(proximoSpawnX + i * espacamentoEntreZombies, ySpawn, 0f);
            GameObject zombie = Instantiate(zombiePrefab, pos, Quaternion.identity);

           
            Zombie script = zombie.GetComponent<Zombie>();
            if (script != null)
            {
                script.velocidade = Random.Range(velocidadeMin, velocidadeMax);
            }
        }

        proximoSpawnX += distanciaEntreGrupos;
        Invoke("SpawnGrupo", Random.Range(intervaloMin, intervaloMax));
    }
}
