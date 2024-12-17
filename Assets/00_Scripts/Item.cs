using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;      // Name of the item
    public Sprite icon;          // Icon for the item

    public virtual void Use()
    {
        Debug.Log("Using item: " + itemName);
    }
}
