using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using UnityEngine.UI;
using Mono.Data.Sqlite;

public class DisplayDatabase : MonoBehaviour
{
    public Text Name;
    public Text KillCount;
    public Text Levels;
    private string dbName = "URI=file:HighScore.db";
    // Start is called before the first frame update
    void Start()
    {
        DisplayData();
        DisplayLevels();
        DisplayKills();
    }

    public void DisplayData()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM HighScore;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        Name.text += reader["Name"] + "\n";
                    reader.Close();
                }

            }
            connection.Close();
        }
    }

    public void DisplayLevels()
    {
        Levels.text += "\n";
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM HighScore;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        Levels.text += reader["Levels"] + "\n"; // add a new line character here
                    reader.Close();
                }

            }
            connection.Close();
        }
    }

    public void DisplayKills()
    {
        KillCount.text += "\n";
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM HighScore;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        KillCount.text += reader["KillCount"] + "\n"; // add a new line character here
                    reader.Close();
                }

            }
            connection.Close();
        }
    }
}
