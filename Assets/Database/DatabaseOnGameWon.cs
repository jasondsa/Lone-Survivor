using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DatabaseOnGameWon : MonoBehaviour
{
    string scoreValue = TimerLevel2.Score;
    public string LevelName = "Level2";
    public InputField NameInput;
    private string dbName = "URI=file:HighScore.db";
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void AddData()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var commmand = connection.CreateCommand())
            {
                commmand.CommandText = "INSERT INTO HighScore(Name, Levels, KillCount) VALUES ('" + NameInput.text + "','" + LevelName + "','" + scoreValue + "');";
                commmand.ExecuteNonQuery();
            }
            connection.Close();
        }
        SceneManager.LoadScene("Main Menu");
    }
}
