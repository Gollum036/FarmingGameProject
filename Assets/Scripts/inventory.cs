using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class Inventory
{
    public class Slot
    {
        public int count;
        public int maxAmount;
    }
}

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public List<Slots> items = new List<Slots>();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        //clicar ativa ou desativa o menu do inventário
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    void Setup()
    {

    }
}