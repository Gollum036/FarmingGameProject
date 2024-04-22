using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarCenoura : MonoBehaviour
{
    private bool hasInteracted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasInteracted)
        {
            // Encontra o objeto com o script Slots
            Slots slotsScript = FindObjectOfType<Slots>();

            if (slotsScript != null)
            {
                // Adiciona uma cenoura ao inventário
                //slotsScript.IncreaseQuantity();
                hasInteracted = true;
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("O objeto com o script Slots não foi encontrado.");
            }
        }
    }
}
