using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] TextMeshPro tmpCountdown;
    private bool loadingBall = false;
    public List<GameObject> ballList = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballList.Add(null); // Add a null entry to the list to trigger the spawning of the first ball
    }
    IEnumerator SpawnBall(int index) {
        loadingBall = true; // Set the loadingBall flag to true to prevent multiple balls from being spawned simultaneously
        for(int i = 3; i > 0; i--)
        {
            tmpCountdown.text = i.ToString(); // Update the countdown text to show the current countdown number
            yield return new WaitForSeconds(1f); // Wait for 1 second before continuing the loop
        }
        GameObject newBall = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity); // Spawn a new ball at the origin with no rotation
        ballList[index] = newBall;
        newBall.GetComponent<BallScript>().sManager = GetComponent<ScoreManager>();

        tmpCountdown.text = "GO!";
        yield return new WaitForSeconds(1f);
        tmpCountdown.text = "";
        loadingBall = false;
    }
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < ballList.Count; i++)
        {
            if (ballList[i] == null && !loadingBall)
            {
                StartCoroutine(SpawnBall(i));
            }
        }
    }
}
