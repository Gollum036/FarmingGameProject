using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemsData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;

    // O CreateAssetMenu permite no Unity criar Item Data objects na pasta dos assets.
}
