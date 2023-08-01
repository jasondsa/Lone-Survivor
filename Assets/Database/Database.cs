using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class Database : MonoBehaviour
{
    [HideInInspector]public string LevelName = "Level1";
    private string dbName = "URI=file:HighScore.db";
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        CreateDB();
    }

    public void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE  TABLE IF NOT EXISTS HighScore (Name VARCHAR(20), Levels VARCHAR(20), KillCount VARCHAR(20));";
                command.ExecuteNonQuery();
            }
            
            connection.Close();
        }
    }
    public void AddData()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();


            // Insert new data
            using (var commmand = connection.CreateCommand())
            {
                commmand.CommandText = "INSERT INTO HighScore (Levels, KillCount) VALUES ('" + LevelName + "','" + UIManager.instance.killCount + "');";
                commmand.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

}
