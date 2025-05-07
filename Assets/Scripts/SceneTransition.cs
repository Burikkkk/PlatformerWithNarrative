using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float fadeDuration = 1f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    IEnumerator FadeIn()
    {
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            fadeGroup.alpha = 1 - (time / fadeDuration);
            yield return null;
        }
        fadeGroup.alpha = 0;
    }

    IEnumerator FadeAndLoadScene(string sceneName)
    {
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            fadeGroup.alpha = time / fadeDuration;
            yield return null;
        }

        fadeGroup.alpha = 1;

        // Загрузка новой сцены
        SceneManager.LoadScene(sceneName);
    }
}
