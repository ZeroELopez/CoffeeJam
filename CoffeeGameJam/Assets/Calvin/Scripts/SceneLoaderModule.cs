using Assets.Scripts.Base.Events;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoaderModule
{
    public static readonly string sceneName_LoadingScreen = "LoadingScreen";

    public static void LoadLevel(string levelName)
    {
        LoadingScreen.Tasks.Push(CO_LoadLevel(levelName));
        UnloadAllScenesExcept("Management");

        ShowLoadingScreen();
    }

    public static void UnloadAllScenesExcept(params string[] scenes)
    {
        LoadingScreen.Tasks.Push(CO_UnloadAllScenesExcept(scenes));
    }


    private static IEnumerator CO_LoadLevel(string levelName)
    {
        yield return "Loading " + levelName;
        AsyncOperation op = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        op.completed += Op_completed;

        while (!op.isDone)
        {
            yield return op.progress;
        }
    }

    private static void Op_completed(AsyncOperation obj)
    {
        EventHub.Instance.PostEvent(new ShowHealthbar());
    }

    private static IEnumerator CO_UnloadAllScenesExcept(params string[] scenes)
    {
        yield return "Unloading scenes";
        List<AsyncOperation> scenesToUnload = new List<AsyncOperation>();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene_i = SceneManager.GetSceneAt(i);
            if (scenes.Any(sceneName => scene_i.name == sceneName) || scene_i.name == sceneName_LoadingScreen)
                continue;
            scenesToUnload.Add(SceneManager.UnloadSceneAsync(scene_i));
        }

        while (scenesToUnload.Any(op => !op.isDone))
        {
            yield return -1;
        }
    }


    public static bool IsLoading() => SceneManager.GetSceneByName(sceneName_LoadingScreen).IsValid();

    public static void ShowLoadingScreen()
    {
        if (!IsLoading() && LoadingScreen.Tasks.Count > 0)
            SceneManager.LoadSceneAsync(sceneName_LoadingScreen, LoadSceneMode.Additive);
    }

    public static void RemoveLoadingScreen()
    {
        SceneManager.UnloadSceneAsync(sceneName_LoadingScreen);
    }
}
