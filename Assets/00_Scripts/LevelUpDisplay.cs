using UnityEngine;
using TMPro; 
public class LevelUpDisplay : MonoBehaviour
{
    public TMP_Text levelUpText; // Reference to the TextMeshPro UI element
    public float displayDuration = 2f; // How long the text stays visible

    private void Start()
    {
        // Ensure the text is initially hidden
        if (levelUpText != null)
        {
            levelUpText.gameObject.SetActive(false);
        }
    }

    public void ShowLevelUpMessage(int playerLevel)
    {
        levelUpText.text = $"Level Up! You are level {playerLevel}!";
        StartCoroutine(DisplayText());
    }

    private System.Collections.IEnumerator DisplayText()
    {
        // Show the text
        levelUpText.gameObject.SetActive(true);

        // Wait for the duration
        yield return new WaitForSeconds(displayDuration);

        // Hide the text
        levelUpText.gameObject.SetActive(false);
    }
}
