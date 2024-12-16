using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName; // Nombre del ítem
    public string description; // Descripción del ítem
    // imagen del ítem
    public Sprite icon; //Icono o imagen para representar el item en la UI

    public Item(string name, string desc, Sprite iconSprite)
    {
        itemName = name;
        description = desc;
        icon = iconSprite; 
    }
}
