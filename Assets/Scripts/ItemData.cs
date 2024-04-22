using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public int id;
    public new string name;
    public string description;
    public Sprite icon;
    public float timeToGrow;
    // Add any other properties needed for the items here
}