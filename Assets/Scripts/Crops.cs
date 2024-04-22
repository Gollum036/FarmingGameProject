using UnityEngine;
using System.Collections;

public class Crop : MonoBehaviour
{
    public GameObject Slots;
    public Sprite[] growthSprites; // Sprites representing different growth stages
    public float timeToGrow = 10f; // Time in seconds for the crop to reach maturity
    private int currentStage = 0; // Current growth stage
    private bool isFullyGrown = false;
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
        isFullyGrown = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Harvest();
        }
    }
    
    
    
    
    
    public void Harvest()
    {
        if (isFullyGrown)
        {
            // Gives items and destroys gameObject

            Slots.GetComponent<Slots>().IncreaseQuantity();
            Debug.Log("Crop harvested!");
            Destroy(gameObject);
        }
        else
        {
            // The crop is not fully grown yet
            Debug.Log("Crop is not fully grown yet!");
        }
    }
}
