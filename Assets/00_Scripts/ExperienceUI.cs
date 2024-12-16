using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import this if you're using TextMeshPro

public class ExperienceUI : MonoBehaviour
{
    [SerializeField] private Slider experienceBar;
    [SerializeField] private TextMeshProUGUI experienceText;

    private void Start()
    {
        UpdateExperiencehUI();
        GameManager.instance.OnExperienceChanged += UpdateExperiencehUI;
    }

    private void OnDestroy()
    {        
        GameManager.instance.OnExperienceChanged -= UpdateExperiencehUI;
    }

    private void UpdateExperiencehUI()
    {
        experienceBar.value = GameManager.instance.experiencePoints;
        experienceText.text = $"{GameManager.instance.experiencePoints}/{GameManager.instance.experienceNeededForLevel}";
    }
}
