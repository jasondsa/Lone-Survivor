using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField]
    Text killCounter_TMP;
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
        killCounter_TMP.text = killCount.ToString();
    }
}
