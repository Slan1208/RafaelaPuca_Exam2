using UnityEngine;

public class Building : MonoBehaviour, IDamageable
{
    public int health = 100;
    public GameObject debrisPrefab;
    public int debrisCount = 10;
    public float debrisSpawnRadius = 1f; 
    public GameObject[] dropItems;
    [SerializeField] private RedFlash redFlash;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Building took {damage} damage. Remaining health: {health}");
        SpawnDebris();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
         if (CompareTag("Toxic"))
        {
            redFlash.StartFlash();
            GameManager.instance.DecreaseHealth(10);
        }
        Debug.Log("Building destroyed!");
        SpawnDebris();
        TryDropItem(); 
        Destroy(gameObject);
    }

    private void SpawnDebris()
    {
        for (int i = 0; i < debrisCount; i++)
        {
            // Generate a random position near the building
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * debrisSpawnRadius;

            // Instantiate a debris prefab at the random position
            GameObject debris = Instantiate(debrisPrefab, randomPosition, Random.rotation);

            // Add a random force to the debris for explosion effect
            Rigidbody rb = debris.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomForce = Random.insideUnitSphere * 5f; // Adjust force magnitude as needed
                rb.AddForce(randomForce, ForceMode.Impulse);
            }
        }
    }
    private void TryDropItem()
    {
        // Ensure there are items in the array
        if (dropItems == null || dropItems.Length == 0)
        {
            Debug.LogWarning("Drop items array is empty!");
            return;
        }

        // 80% chance to drop an item
        if (Random.value <= 0.8f) // 80% chance to drop
        {
            int randomIndex = Random.Range(0, dropItems.Length);
            GameObject selectedItem = dropItems[randomIndex];

            // Spawn the item slightly above the building
            Vector3 spawnPosition = transform.position + Vector3.up * 15f; // Adjust height as needed
            Instantiate(selectedItem, spawnPosition, Quaternion.identity);

            Debug.Log($"Dropped item: {selectedItem.name}");
        }
        else
        {
            Debug.Log("No item dropped.");
        }
    }
}
