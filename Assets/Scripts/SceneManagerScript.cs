using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public int gameMode;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive); // Load the scene named "Menu" when this script starts
    }

    public void MatchStart(int mode)
    {
        SceneManager.UnloadSceneAsync("Menu");
        gameMode = mode;
        SceneManager.LoadScene("Main", LoadSceneMode.Additive); // Load the scene named "Main" when the match starts
    }
    public void EndMatch()
    {
        SceneManager.UnloadSceneAsync("Main");
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive); // Load the scene named "Menu" when returning to the menu
    }
    // Set the newly loaded scene as the active
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event to call the OnSceneLoaded method when a new scene is loaded

    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from the sceneLoaded event to prevent memory leaks when this script is disabled
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene); // Set the active scene to the newly loaded scene to ensure that it is the one being displayed
    }
}
