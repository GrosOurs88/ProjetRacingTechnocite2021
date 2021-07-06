using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
using UnityEngine.SceneManagement;

public class BuildStartManagerScript : MonoBehaviour
{
    public List<string> scenesToLoadAtStart = new List<string>();

    private string thisSceneName;

    void Start()
    {
        thisSceneName = SceneManager.GetActiveScene().name;

        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        AsyncOperation asyncLoadLevel;

        for (int i = 0; i < scenesToLoadAtStart.Count; i++)
        {
            asyncLoadLevel = SceneManager.LoadSceneAsync(scenesToLoadAtStart[i], LoadSceneMode.Additive);
            while (!asyncLoadLevel.isDone)
            {
                yield return null;
            }
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));
        SceneManager.UnloadSceneAsync(thisSceneName);
    }
}
