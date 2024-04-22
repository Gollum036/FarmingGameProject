using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarCenoura : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        Slots slotsScript = FindObjectOfType<Slots>();
        Destroy(gameObject);
        slotsScript.IncreaseQuantity();
    }
}
