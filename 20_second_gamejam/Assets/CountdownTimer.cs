using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 20;
    public bool timerIsRunning = false;

    [SerializeField] GameObject infoScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] Text text;
    [SerializeField] GameObject lvl_over_check;
    private void Start()
    {
        Time.timeScale = 0f;
        winScreen.SetActive(false);
        // Starts the timer automatically
        //timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                text.text = timeRemaining.ToString();
                if(lvl_over_check == null)
                {
                    winScreen.SetActive(true);
                    timerIsRunning = false;
                }
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                text.text = timeRemaining.ToString();
                timerIsRunning = false;
                SceneManager.LoadScene(0);
            }
        }
    }

    public void OnStartPressed()
    {
        timerIsRunning = true;
        Time.timeScale = 1f;
        infoScreen.SetActive(false);
    }

    public void OnPlayAgainPressed()
    {
        SceneManager.LoadScene(0);
    }
}
