using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public enum SoundEnum
    {
        Scale,
        Select
    }

    [Serializable]
    public class Sound
    {
        public SoundEnum SoundEnum;
        public AudioClip Clip;
    }

    [SerializeField] Sound[] soundsList;
    private Dictionary<SoundEnum, AudioClip> soundsDictionary = new Dictionary<SoundEnum, AudioClip>();
    private int currentSound = 0;

    private void Start()
    {
        for (int i = 0; i < soundsList.Length; i++)
        {
            soundsDictionary.Add(soundsList[i].SoundEnum, soundsList[i].Clip);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Play();
        }
    }

    public void PlayWithKey(SoundEnum key)
    {
        audioSource.clip = soundsDictionary[key];
        audioSource.Play();
    }

    void Play()
    {
        currentSound++;
        if (currentSound == soundsList.Length)
        {
            currentSound = 0;
        }

        audioSource.clip = soundsList[currentSound].Clip;
        audioSource.Play();
    }
}