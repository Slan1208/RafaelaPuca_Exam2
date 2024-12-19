using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Start()
    {
        UpdateHealthUI();
        GameManager.instance.OnHealthChanged += UpdateHealthUI;
    }

    private void OnDestroy()
    {        
        GameManager.instance.OnHealthChanged -= UpdateHealthUI;
    }

    private void UpdateHealthUI()
    {

        healthBar.value = GameManager.instance.health;
        healthText.text = $"{GameManager.instance.health}/{GameManager.instance.maxHealth}";
    }
}
