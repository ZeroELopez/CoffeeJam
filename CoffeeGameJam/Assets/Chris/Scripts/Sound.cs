using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    public AudioClip[] clipVariants;


    [Range(0f, 1f)]
    public float volumeMin = 1;
    [Range(0f, 1f)]
    public float volumeMax = 1;

    [Range(.1f, 3f)]
    public float pitchMin = 1;
    [Range(.1f, 3f)]
    public float pitchMax = 1;

    public int[] startingPoints = new int[1] { 0 };
}
