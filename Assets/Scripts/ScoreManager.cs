using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreA;
    [SerializeField] TextMeshPro scoreB;
    [SerializeField] PauseManager pauseManager;
    [SerializeField] int maxScore = 1;
    public List<int> scores = new List<int>() { 0, 0 }; // Initialize the scores for both players to 0
    
    public void scoreGoal(int index)
    {
        scores[index]++;
        if(index == 0)
        {
            scoreA.text = scores[index].ToString(); // Update the score display for player A
        }
        else
        {
            scoreB.text = scores[index].ToString(); // Update the score display for player B
        }
    }
    void Win(TextMeshPro winnerTMP)
    {
        winnerTMP.text = "Win!"; // Display "Win!" for the winning player
        winnerTMP.color = Color.green;
    }
    void Lose(TextMeshPro loserTMP)
    {
        loserTMP.text = "Lose"; // Display "Lose" for the losing player
        loserTMP.color = Color.gray;
    }
    void Update()
    {
        if (scores[0] >= maxScore)
        {
            Win(scoreA); // Call the Win method for player A if their score reaches the maximum score
            Lose(scoreB); // Call the Lose method for player B if player A wins
            pauseManager.Pause(true); // Pause the game and indicate that the match has ended
        }
        else if (scores[1] >= maxScore)
        {
            Win(scoreB); // Call the Win method for player B if their score reaches the maximum score
            Lose(scoreA);
            pauseManager.Pause(true); // Pause the game and indicate that the match has ended
        }
    }
}
