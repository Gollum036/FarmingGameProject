using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slots : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI quantityText;
    private int quantity = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the quantity text
        UpdateQuantityText();
    }

    // Function to increase the quantity
    public void IncreaseQuantity()
    {
        quantity++;
        UpdateQuantityText();
    }

    // Function to update the quantity text
    private void UpdateQuantityText()
    {
        quantityText.text = "Quantity: " + quantity.ToString();
    }
    
}
