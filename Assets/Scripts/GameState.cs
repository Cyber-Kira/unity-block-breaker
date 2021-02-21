using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    // configuration parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    // state
    [SerializeField] int currentScore = 0; //add to see a number
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TMP_Text scoreText;

    private void Start()
    {
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        updateText();
    }

    private void updateText()
    {
        scoreText.text = currentScore.ToString();
    }
}