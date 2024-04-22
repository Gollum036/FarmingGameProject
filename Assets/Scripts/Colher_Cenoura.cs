using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colher_Cenoura : MonoBehaviour
{
    public GameObject cenouraPrefab;
    public Sprite[] sprites; // Array contendo os sprites para cada est�gio
    public float spawnRadius = 1.0f;
    private bool hasSpawned = false;

    private SpriteRenderer spriteRenderer; // Refer�ncia para o componente SpriteRenderer

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obt�m o componente SpriteRenderer
    }

    void Update()
    {
        // Verifica se a tecla de espa�o foi pressionada e se o spawn ainda n�o ocorreu
        if (!hasSpawned && Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRandomCenouras();
            hasSpawned = true;
            NextSprite(); // Troca o sprite ap�s o spawn
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasSpawned && other)
        {
            SpawnRandomCenouras();
            hasSpawned = true;
            NextSprite(); // Troca o sprite ap�s o spawn
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

    // Fun��o para mudar para o pr�ximo sprite no array
    void NextSprite()
    {
        // Verifica se existem sprites definidos
        if (sprites != null && sprites.Length > 0)
        {
            int currentIndex = spriteRenderer.sprite != null ? System.Array.IndexOf(sprites, spriteRenderer.sprite) : -1;
            int nextIndex = (currentIndex + 1) % sprites.Length;
            spriteRenderer.sprite = sprites[nextIndex];
        }
    }
}

