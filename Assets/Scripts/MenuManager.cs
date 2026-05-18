using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private GameObject sceneManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        sceneManager = GameObject.Find("SceneManager"); // Find the GameObject named "SceneManager" and assign it to the sceneManager variable
    }

    public void VsCpu()
    {
        sceneManager.GetComponent<SceneManagerScript>().MatchStart(0); // Start a match against the CPU (mode 0)
    }
    public void VsPlayer()
    {
        sceneManager.GetComponent<SceneManagerScript>().MatchStart(1); // Start a match against another player (mode 1)
    }
    public void Exit()
    {
        Application.Quit(); // Quit the application
    }
}
