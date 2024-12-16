using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ButtonStartGame()
    {
        GameManager.instance.ResetHealth();
        SceneManager.LoadScene("Game_Stage01");
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu_Main");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit(); // Exits the application (won't work in the editor)
    } 
}
