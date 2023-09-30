using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneLoaderModule.LoadLevel(sceneName);
    }
}