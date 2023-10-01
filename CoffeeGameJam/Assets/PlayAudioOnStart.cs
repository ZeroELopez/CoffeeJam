using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAudioOnStart : MonoBehaviour
{
    [SerializeField] AudioSource source;

    [SerializeField] string[] LevelNames;

    [SerializeField] string[] LevelStart;

    [SerializeField] string[] LevelEnd;

    Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
    string[] lines;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < LevelNames.Length; i++)
            dictionary.Add(LevelNames[i], new string[2] { LevelStart[i], LevelEnd[i] });

        if (dictionary.TryGetValue(SceneManager.GetActiveScene().name, out lines))
            AudioManager.PlaySound(lines[0], source);
    }

    public void EndLevelLine()
    {
        if (dictionary.TryGetValue(SceneManager.GetActiveScene().name, out lines))
        AudioManager.PlaySound(lines[1], source);
    }

}
