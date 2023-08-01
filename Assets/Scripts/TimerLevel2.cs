using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TimerLevel2 : MonoBehaviour
{
    public float timeRemaining = 120;
    public Text timeText;
    int currentKillCount = UIManager.instance.killCount;
    public static string Score;

    void Update()
    {
        if (UIManager.instance != null) // check if UIManager instance is not null
        {
            currentKillCount = UIManager.instance.killCount;
        }
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining - minutes * 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            Score = currentKillCount.ToString();
            SceneManager.LoadScene("GameWon");
        }
    }
}
