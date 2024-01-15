using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform winningPoint;
    public Text timeText; // Reference to a UI Text component to display time

    private float startTime; // Time when the game starts
    private float endTime;   // Time when the game ends

    void Start()
    {
        startTime = Time.time; // Record the start time when the game starts
    }

    void Update()
    {
        // Check if the player has reached the winning point
        if (player.position.x >= winningPoint.position.x)
        {
            Debug.Log("CONGRATULATION!!! YOU FINNISHED!!!");
            EndGame();
        }

        // Check if the player fell off the terrain boundaries (assuming the y-axis is the vertical axis)
        if (player.position.y < -10f)
        {
            EndGame();
        }

        // Update timeText to display the current time played during the game
        timeText.text = "Time: " + FormatTime(Time.time - startTime);
    }

    void EndGame()
    {
        endTime = Time.time; // Record the end time when the game ends

        // Optionally, you can add more logic here for winning or losing the game.

        // Display the total time played
        Debug.Log("Game Over! Total Time Played: " + FormatTime(endTime - startTime));

        // Uncomment the following line if you're building for standalone platforms (PC, Mac, Linux)
        // Application.Quit();

        // Uncomment the following line if you're testing in the Unity Editor
         UnityEditor.EditorApplication.isPlaying = false;

        // Uncomment the following line if you're building for mobile platforms (iOS, Android)
        // UnityEngine.Application.Quit();
    }

    // Helper method to format time as minutes and seconds
    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
