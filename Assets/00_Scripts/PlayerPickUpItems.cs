using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private int exp = 10;
    public FoodItem foodItem;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("collided with item");
        if (other.CompareTag("Experience"))
        {
            GameManager.instance.GetExperience(exp);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Food"))
        {
            InventoryManager.instance.AddItem(foodItem);
            Destroy(other.gameObject);
        }
    }
}
