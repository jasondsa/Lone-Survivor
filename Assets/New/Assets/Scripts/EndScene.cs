using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    [HideInInspector]
    public string endTime;

    void Start()
    {
        //endTime = CountStateController.time;
    }

    void Update()
    {
        endTime = CountStateController.time;
        if (endTime != "08:00")
        {

        }
        else
        {
            SceneManager.LoadScene("GameWon");
        }
    }
}
