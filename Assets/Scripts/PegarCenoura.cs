using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarCenoura : MonoBehaviour
{
    public GameObject Slots;
    void OnTriggerEnter2D(Collider2D other)
    {
        Slots.GetComponent<Slots>().IncreaseQuantity();
        Destroy(gameObject);
    }
}
