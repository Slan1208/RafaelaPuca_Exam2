using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera playerCamera;
    public float attackRange = 3f;
    public int attackDamage = 20;
    

    public LayerMask attackableLayers;
    public float attackCooldown = 0.5f;

    private float nextAttackTime = 0f;

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
        Debug.Log("Player attacks!");

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackRange, attackableLayers))
        {
            Debug.Log("Hit: " + hit.collider.name);

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
