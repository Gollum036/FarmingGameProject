using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public ItemsData itemType;
    public int condition;

    public ItemInstance(ItemsData itemData)
    {
        itemType = itemData;
        
    }
}

