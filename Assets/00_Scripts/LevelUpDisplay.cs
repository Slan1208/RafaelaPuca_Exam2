using UnityEngine;
using TMPro; 
public class LevelUpDisplay : MonoBehaviour
{
    public TMP_Text levelUpText;
    public float displayDuration = 2f;

    private void Start()
    {
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
        levelUpText.gameObject.SetActive(true);

        yield return new WaitForSeconds(displayDuration);

        levelUpText.gameObject.SetActive(false);
    }
}
