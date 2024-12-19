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
        Collider buildingCollider = GetComponent<Collider>();
        if (buildingCollider == null)
        {
            Debug.LogWarning("Building does not have a collider!");
            return;
        }

        Vector3 buildingCenter = buildingCollider.bounds.center;
        Vector3 buildingSize = buildingCollider.bounds.extents;

        for (int i = 0; i < debrisCount; i++)
        {
            Vector3 randomDirection = Random.onUnitSphere;
            randomDirection.y = Mathf.Abs(randomDirection.y);

            Vector3 spawnPosition = buildingCenter + randomDirection * (buildingSize.magnitude + debrisSpawnRadius);

            GameObject debris = Instantiate(debrisPrefab, spawnPosition, Random.rotation);

            Rigidbody rb = debris.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomForce = randomDirection * Random.Range(5f, 10f);
                rb.AddForce(randomForce, ForceMode.Impulse);
            }
        }
    }
    private void TryDropItem()
    {
        if (dropItems == null || dropItems.Length == 0)
        {
            Debug.LogWarning("Drop items array is empty!");
            return;
        }

        if (Random.value <= 0.8f)
        {
            int randomIndex = Random.Range(0, dropItems.Length);
            GameObject selectedItem = dropItems[randomIndex];

            Vector3 spawnPosition = transform.position + Vector3.up * 15f;
            Instantiate(selectedItem, spawnPosition, Quaternion.identity);

            Debug.Log($"Dropped item: {selectedItem.name}");
        }
        else
        {
            Debug.Log("No item dropped.");
        }
    }
}
