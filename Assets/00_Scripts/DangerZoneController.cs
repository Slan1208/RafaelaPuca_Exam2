using UnityEngine;
using System.Collections;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int damagePerTick = 5;   // Damage dealt per tick
    [SerializeField] private float damageInterval = 1f; // Interval in seconds between damage
    [SerializeField] private RedFlash redFlash;      // Reference to the RedFlash script

    private bool playerInside = false; // Tracks if the player is inside the zone
    private Coroutine damageCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            damageCoroutine = StartCoroutine(DealDamageOverTime());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop dealing damage when the player exits
            playerInside = false;

            // Stop the damage coroutine if it’s running
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    private IEnumerator DealDamageOverTime()
    {
        while (playerInside)
        {
            Debug.Log("playerInside!");
            redFlash.StartFlash();
            GameManager.instance.DecreaseHealth(damagePerTick);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
