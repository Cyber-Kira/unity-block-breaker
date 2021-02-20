using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // configuration parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    // state
    [SerializeField] int currentScore = 0; //add to see a number
    [SerializeField] int pointsPerBlockDestroyed = 10;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }
}
