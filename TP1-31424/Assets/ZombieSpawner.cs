using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform jogador;
    public float distanciaInicial = 15f; 
    public float distanciaSpawnMin = 10f;
    public float distanciaSpawnMax = 14f;
    public float intervaloMin = 0.3f; 
    public float intervaloMax = 0.6f;
    public float ySpawn = -1.8f;
    public float espacamentoMin = 0.7f;
    public float espacamentoMax = 1.2f;

    private float tempoProximoSpawn;
    private GameObject ultimoZombie;
    private bool primeiroSpawnFeito = false;

    void Start()
    {
        tempoProximoSpawn = Time.time + 2f; 
    }

    void Update()
    {
        if (Time.time >= tempoProximoSpawn)
        {
            if (ultimoZombie != null && jogador.position.x <= ultimoZombie.transform.position.x + 1f)
                return;

            int quantidadeZombies = Random.Range(1, 5); 

            float distancia = primeiroSpawnFeito ? Random.Range(distanciaSpawnMin, distanciaSpawnMax) : distanciaInicial;

            Vector3 baseSpawn = new Vector3(jogador.position.x + distancia, ySpawn, 0f);

            for (int i = 0; i < quantidadeZombies; i++)
            {
                float espacamento = Random.Range(espacamentoMin, espacamentoMax);
                Vector3 pos = baseSpawn + new Vector3(i * espacamento, 0, 0);
                GameObject z = Instantiate(zombiePrefab, pos, Quaternion.identity);

                if (i == quantidadeZombies - 1)
                    ultimoZombie = z;
            }

            primeiroSpawnFeito = true;
            tempoProximoSpawn = Time.time + Random.Range(intervaloMin, intervaloMax);
        }
    }
}
