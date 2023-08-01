using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public AudioSource menuMusic;
    public GameObject LoadingScreen;
    public Image LoadingBarFill;
    public float speed;

    private void Start()
    {
        menuMusic.Play();
    }

    public void LoadScene(int sceneId)
    {
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(LoadSceneAsync(sceneId));
        menuMusic.Stop();
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
    }
}