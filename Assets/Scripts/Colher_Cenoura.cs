using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colher_Cenoura : MonoBehaviour
{
    public GameObject cenouraPrefab;
    public float spawnRadius = 1.0f;
    private bool hasSpawned = false;

    void Update()
    {
        // Verifica se a tecla de espa�o foi pressionada e se o spawn ainda n�o ocorreu
        if (!hasSpawned && Input.GetKeyDown(KeyCode.Space))
        {
            hasSpawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (!hasSpawned && other)
        {
            SpawnRandomCenouras();
            hasSpawned = true;
        }
    }

    // Fun��o para spawnar um n�mero aleat�rio de cenouras entre 2 e 5
    void SpawnRandomCenouras()
    {
        int quantidadeCenouras = Random.Range(2, 6); // De 2 a 5 cenouras

        for (int i = 0; i < quantidadeCenouras; i++)
        {
            Vector2 spawnOffset = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = transform.position + new Vector3(spawnOffset.x, spawnOffset.y, 0);
            Instantiate(cenouraPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

