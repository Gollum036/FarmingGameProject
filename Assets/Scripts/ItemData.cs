using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public Transform itemsParent;
    public GameObject inventoryUI;
    public Text itemNameText;
    public Text itemDescriptionText;

    public Item selectedItem;

    public ItemDatabase itemDatabase;

    public InventorySlot[] slots;

    void Start()
    {
        itemDatabase = GetComponent<ItemDatabase>();
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void AddItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItemById(id);
        items.Add(itemToAdd);

        UpdateUI();
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = items.Find(item => item.id == id);
        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
        }

        UpdateUI();
    }

    public void SelectItem(Item item)
    {
        selectedItem = item;
        itemNameText.text = selectedItem.name;
        itemDescriptionText.text = selectedItem.description;
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                slots[i].AddItem(items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}

[Serializable]
public class Item
{
    public int id;
    public string name;
    public string description;
    public int price;
    public Sprite icon; // Added icon field
    // Add any other properties you need for your items here
}

[Serializable]
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Start()
    {
        // Initialize your items here
    }

    public Item GetItemById(int id)
    {
        return items.Find(item => item.id == id);
    }
}