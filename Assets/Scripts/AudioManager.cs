using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//this is the audio controller for sounds
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject audioSourcePrefab;
    [SerializeField] int audioSourceCount;

    List<AudioSource> audioSources;

    private void Start()
    {
        Init();
    }

    //creating multiple audio sources
    private void Init()
    {
        audioSources = new List<AudioSource>();
        for(int i = 0; i < audioSourceCount; i++)
        {
            GameObject go = Instantiate(audioSourcePrefab, transform);
            go.transform.localPosition = Vector3.zero;
            audioSources.Add(go.GetComponent<AudioSource>());
        }
    }

    //checking if any audio sources are playing or not
    public void Play(AudioClip audioClip)
    {
        if(audioClip ==null) { return; }

        AudioSource audioSource = GetFreeAudioSource();

        audioSource.clip = audioClip;
        audioSource.Play();
    }

    //playing on a free audio source that isnt playing a sound already
    private AudioSource GetFreeAudioSource()
    {
        for(int i = 0; i < audioSources.Count; i++)
        {
            if(audioSources[i].isPlaying == false)
            {
                return audioSources[i];
            }
        }
        return audioSources[0];
    }

    internal void Play(object onPlowUsed)
    {
        
    }

}
