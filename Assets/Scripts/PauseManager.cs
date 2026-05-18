using Unity.VisualScripting;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuPrefab;
    private GameObject pauseMenuInstance;
    private GameObject sceneManager;
    private bool isEnded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");
    }

    public void Resume()
    {
        Destroy(pauseMenuInstance); // Destroy the pause menu instance to remove it from the screen
        Time.timeScale = 1f; // Resume the game by setting time scale back to normal
    }    
    public void Pause(bool ended)
    {
        if (!isEnded)
        {
            isEnded = ended; // Set the isEnded flag to indicate whether the match has ended or not
            if (Time.timeScale == 0f) {
                Resume(); // If the game is paused, call the Resume method to resume the game
                return;
            }
            Time.timeScale = 0f; // Pause the game by setting time scale to 0
            pauseMenuInstance = Instantiate(pauseMenuPrefab, Vector3.zero, Quaternion.identity); // Instantiate the pause menu prefab at the center of the screen
            pauseMenuInstance.GetComponent<PauseScript>().pauseManager = this; // Set the pauseManager reference in the PauseScript to this instance of the PauseManager
            if (isEnded)
            {
                pauseMenuInstance.transform.GetChild(0).gameObject.SetActive(false); // Deactivate the first child of the pause menu instance
                pauseMenuInstance.transform.GetChild(1).gameObject.SetActive(false); // Deactivate the second child of the pause menu instance        }
            }
        }
    }
    public void Quit()
    {
        Time.timeScale = 1f;
        Destroy(pauseMenuInstance); // Destroy the pause menu instance to remove it from the screen
        sceneManager.GetComponent<SceneManagerScript>().EndMatch(); // End the match and return to the main menu
    }
}
