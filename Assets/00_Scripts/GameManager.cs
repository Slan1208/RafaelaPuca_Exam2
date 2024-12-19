using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public LevelUpDisplay levelUpDisplay;

    public int level = 1;
    public int maxHealth = 100;
    public int health = 100;
    public event Action OnHealthChanged;
    public event Action OnExperienceChanged;

    public int experiencePoints = 0;
    public int experienceNeededForLevel = 50;
    
    public void LevelUp() {
        Debug.Log("LEVEL UP");
        level += 1;
        levelUpDisplay.ShowLevelUpMessage(level);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Maté a la instancia.. vive muchacho");
        }
    } // Singleton. No abrir.

    private void Start()
    {
        // capeo a 60fps
        Application.targetFrameRate = 60;
    }

    public void IncreaseHealth(int amount)
    {
        health += amount;
        Debug.Log("Health increased " + health);
    }

    public void DecreaseHealth(int amount)
    {
        health -= amount;
        OnHealthChanged?.Invoke();
        Debug.Log("Health decreased " + health);
        if (health <= 0) {
            GameOver();
        }
    }

    public void GetExperience(int exp) {
        experiencePoints += exp;
        Debug.Log($"Gained experience! Total: {experiencePoints}");
        OnExperienceChanged?.Invoke();
        if (experiencePoints == experienceNeededForLevel) {
            LevelUp();
            experiencePoints = 0;
            OnExperienceChanged?.Invoke();
        }
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu_Restart");
    }

    public void ResetHealth()
    {
        health = 100;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    } 
}
