using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private int exp = 10;
    
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("collided with item");
        // Check for Experience Item
        if (other.CompareTag("Experience"))
        {
            GameManager.instance.GetExperience(10);
            Destroy(other.gameObject);
        }
        // Check for Food Item
        else if (other.CompareTag("Food"))
        {
            // foodItems += 1; // Add food to inventory
            // Debug.Log($"Picked up food! Total: {foodItems}");
            // Destroy(other.gameObject); // Remove the item
        }
    }
}
