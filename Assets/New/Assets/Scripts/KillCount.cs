using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCount : MonoBehaviour
{
    public static KillCount instance;
    [SerializeField]
    TextMeshProUGUI killCounter_TMP;
    [HideInInspector]
    public int killCount;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateKillCounterUI()
    {
        CountStateController.Score = killCount;
        killCounter_TMP.text = killCount.ToString();
    }
}
