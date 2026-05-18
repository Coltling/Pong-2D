using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    [SerializeField] GameObject rival;
    private GameObject sceneManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");
        SceneManagerScript sms = sceneManager.GetComponent<SceneManagerScript>();
        if (sms.gameMode == 0) 
        { 
            rival.GetComponent<RivalAI>().enabled = true;
        }
        else if(sms.gameMode == 1)
        {
            rival.GetComponent<PlayerContols>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
