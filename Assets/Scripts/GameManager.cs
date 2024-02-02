using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField]
    private int timeToEnd = 180;
    public bool gamePaused { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        if(timeToEnd <= 0)
        {
            timeToEnd = 180;
        }
        InvokeRepeating(nameof(Stopper), 1, 1);
    }

    private void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd} sek");
    }

    public void PausGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1;
        gamePaused = false;
    }

    private void PauseCheck()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PausGame();
            }
        }
    }

    private void Update()
    {
        PauseCheck();
    }

}
