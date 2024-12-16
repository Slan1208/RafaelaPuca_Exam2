using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // Assign the PauseMenu canvas in the Inspector
    private bool isPaused = false;

    void Update()
    {
        // Check for the P key
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Pause game time
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume game time
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor back to the center
        Cursor.visible = false; // Hide the cursor
    }
}
