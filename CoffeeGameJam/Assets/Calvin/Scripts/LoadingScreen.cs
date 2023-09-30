using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public static Stack<IEnumerator> Tasks = new Stack<IEnumerator>();

    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private TextMeshProUGUI text_Progress;
    [SerializeField] private TextMeshProUGUI text_Info;

    [SerializeField] private float fadeDuration = 0.2f;


    private void Awake()
    {
        UpdateInfo("");
        UpdateProgress(-1);

        StartCoroutine(LoadingScreenFadeIn());
    }

    private void CheckForNextTask()
    {
        if (Tasks.TryPop(out IEnumerator nextTask))
            StartCoroutine(RunTask(nextTask));
        else
            StartCoroutine(LoadingScreenFadeOut());
    }

    public void UpdateProgress(float progress)
    {
        if (progress < 0)
            progress = -10;

        UpdateProgress(Mathf.CeilToInt(progress * 100));
    }

    public void UpdateProgress(int progress)
    {
        if (text_Progress == null)
            return;

        if (progress >= 0)
            text_Progress.text = $"({progress:D2}%) Loading...";
        else
            text_Progress.text = "Loading...";
    }


    public void UpdateInfo(string info)
    {
        if (text_Info == null)
            return;

        text_Info.text = info;
    }

    private IEnumerator RunTask(IEnumerator task)
    {
        while (task.MoveNext())
        {
            object current = task.Current;

            if (current is string)
                UpdateInfo((string)current);
            else if (current is float)
                UpdateProgress((float)current);
            else if (current is int)
                UpdateProgress((int)current);

            yield return current;
        }

        CheckForNextTask();
    }


    private IEnumerator LoadingScreenFadeIn()
    {
        yield return StartCoroutine(LoadingScreenFade(0, 1));

        CheckForNextTask();
    }

    private IEnumerator LoadingScreenFadeOut()
    {
        yield return StartCoroutine(LoadingScreenFade(1, 0));

        SceneLoaderModule.RemoveLoadingScreen();
    }

    private IEnumerator LoadingScreenFade(float startValue, float targetValue)
    {
        if (canvasGroup != null)
        {
            float time = 0;
            while (time < fadeDuration)
            {
                time += Time.unscaledDeltaTime;
                canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, time / fadeDuration);
                yield return null;
            }
        }
    }
}
