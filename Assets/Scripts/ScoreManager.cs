using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreA;
    [SerializeField] TextMeshPro scoreB;
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
}
