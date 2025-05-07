using UnityEngine;
using System.Collections;

public class MusicFader : MonoBehaviour
{
    [Header("Настройки")]
    public AudioSource currentSource;
    public float fadeDuration = 1.5f;

    [Header("Новый трек (перетащи сюда)")]
    public AudioClip newClip;

    // Вызывается для смены музыки
    [ContextMenu("Switch to New Clip")]
    public void SwitchToNewClip()
    {
        if (newClip != null)
        {
            StartCoroutine(FadeOutIn(newClip));
        }
        else
        {
            Debug.LogWarning("AudioClip не назначен!");
        }
    }

    private IEnumerator FadeOutIn(AudioClip clip)
    {
        float t = 0f;
        float startVolume = currentSource.volume;

        // Фейд-аут
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            currentSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        currentSource.Stop();
        currentSource.clip = clip;
        currentSource.Play();

        // Фейд-ин
        t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            currentSource.volume = Mathf.Lerp(0, startVolume, t / fadeDuration);
            yield return null;
        }

        currentSource.volume = startVolume;
    }
}
