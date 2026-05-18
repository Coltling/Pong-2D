using System.Collections;
using TMPro;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public PauseManager pauseManager;

    public void ResumeButton()
    {
        pauseManager.Resume(); // Call the Resume method of the PauseManager to resume the game
    }
    public void QuitButton()
    {
        pauseManager.Quit(); // Call the Quit method of the PauseManager to end the match and return to the main menu
    }
}
