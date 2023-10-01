using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip[] Songs;
    int onSong = -1;
    [SerializeField] AudioSource[] audioSources;
    AudioSource oldSource, newSource;
    string[] lines;
    [SerializeField] AnimationCurve curve;
    [SerializeField] float length;
    float time;
    // Start is called before the first frame update

    private void Awake()
    {
        EntityEventTracker.onLevelStart += NewSong;
        EntityEventTracker.globalOnKill += NewSong;
    }

    private void OnDisable() =>        EntityEventTracker.onLevelStart -= NewSong;

    void NewSong()
    {
        SwitchSource();
        onSong++;

        newSource.clip = Songs[onSong];
        newSource.Play();
        time = 0;
    }


    private void Update()
    {
        if (time > length)
            return;

        time += Time.deltaTime;
        oldSource.volume =  1 - curve.Evaluate(time / length);
        newSource.volume = curve.Evaluate(time / length);
    }

    void SwitchSource()
    {
        if (audioSources[1] == null)
            return;

        if (audioSources[1].volume > audioSources[0].volume)
        {
            Debug.Log("Set A");
            oldSource = audioSources[1];
            newSource = audioSources[0];
        }
        else
        {
            Debug.Log("Set B");

            oldSource = audioSources[0];
            newSource = audioSources[1];

        }
    }
}
