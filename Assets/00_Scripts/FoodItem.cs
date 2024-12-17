using UnityEngine;

[CreateAssetMenu(fileName = "New Food Item", menuName = "Inventory/Food Item")]
public class FoodItem : Item
{
    public int healAmount; // Amount of health the food restores

    public override void Use()
    {
        Debug.Log("Eating food: " + itemName + " for " + healAmount + " HP");
        GameManager.instance.IncreaseHealth(healAmount);
    }
}