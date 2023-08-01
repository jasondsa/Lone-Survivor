using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Database databaseScript;
    public float timeRemaining = 120;
    public Text timeText;
    public GameObject LoadingScreen;
    public Image LoadingBarFill;
    public float speed;
    private bool hasInsertedData = false;

    private void Start()
    {
        databaseScript = FindObjectOfType<Database>();

    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining - minutes * 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if (!hasInsertedData)
        {
            hasInsertedData = true;
            databaseScript.AddData();
            StartCoroutine(LoadSceneAsync(2));
        }
    }
    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / speed);
            LoadingBarFill.fillAmount = progressValue;

            yield return null;
        }
        yield return new WaitForSeconds(1f);
    }

}
