using UnityEngine;
using System.Collections;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int damagePerTick = 5;
    [SerializeField] private float damageInterval = 1f;
    [SerializeField] private RedFlash redFlash;

    private bool playerInside = false;
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
            playerInside = false;

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
