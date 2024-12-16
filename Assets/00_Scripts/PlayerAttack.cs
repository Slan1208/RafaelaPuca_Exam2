using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public float attackRange = 3f; // Range of the attack
    public int attackDamage = 20; // Damage per attack
    

    public LayerMask attackableLayers; // Layers that can be attacked
    public float attackCooldown = 0.5f; // Cooldown time between attacks

    private float nextAttackTime = 0f; // Tracks when the player can attack again

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void Attack()
    {
        // Play attack animation (if applicable)
        Debug.Log("Player attacks!");

        // Cast a ray from the center of the screen
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackRange, attackableLayers))
        {
            Debug.Log("Hit: " + hit.collider.name);

            // Check if the hit object has a damageable component
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                GameManager gameManager = FindObjectOfType<GameManager>();
                int caluclateDamage = gameManager.level * attackDamage;
                damageable.TakeDamage(caluclateDamage);
            }
        }
    }
}
