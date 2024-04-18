using UnityEngine;
using System.Collections;

public class Crop : MonoBehaviour
{
    public Sprite[] growthSprites; // Sprites representing different growth stages
    public float timeToGrow = 10f; // Time in seconds for the crop to reach maturity
    private int currentStage = 0; // Current growth stage

    private void Start()
    {
        // Start growing the crop when it's planted
        StartCoroutine(Grow());
    }

    private IEnumerator Grow()
    {
        float timer = 0f;

        while (timer < timeToGrow)
        {
            // Update the sprite based on the current growth stage
            int index = Mathf.FloorToInt((float)currentStage / growthSprites.Length * (growthSprites.Length - 1));
            GetComponent<SpriteRenderer>().sprite = growthSprites[index];

            // Wait for a short time
            yield return new WaitForSeconds(1f);

            // Increase the timer
            timer += 1f;
        }

        // Crop is fully grown
        Harvest();
    }

    private void Harvest()
    {
        // Handle harvesting the crop (e.g., give resources to the player)
        // You can also destroy the crop object here
    }
}
