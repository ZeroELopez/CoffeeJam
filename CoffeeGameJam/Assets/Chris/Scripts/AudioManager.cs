using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void PlaySound(string name, AudioSource source)
    {
        foreach(Sound sound in instance.sounds)
        {
            if (sound.name == name)
            {
                source.clip = sound.clip;

                if (sound.clipVariants.Length > 0)
                    source.clip = sound.clipVariants[
                        Mathf.Clamp(Random.Range(0, sound.clipVariants.Length),0, sound.clipVariants.Length - 1)
                        ];


                source.volume = Random.Range(sound.volumeMin, sound.volumeMax);
                source.pitch = Random.Range(sound.pitchMin, sound.pitchMax);
                source.timeSamples = sound.startingPoints[Random.Range(0, sound.startingPoints.Length - 1)];
                
                source.Play();
            }
        }
    }
}
