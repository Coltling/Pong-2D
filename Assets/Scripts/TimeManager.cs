using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // Increment the timer by the time elapsed since the last frame
    }
}
