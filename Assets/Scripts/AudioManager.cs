using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public List<Sound> sounds = new List<Sound>();
    private int currentTrack = 0;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.GetComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volumne;
        }
    }

    public void PlayNext()
    {
        sounds[currentTrack].source.Stop();
        currentTrack++;
        if (currentTrack > sounds.Count - 1)
        {
            currentTrack = 0;
        }
        PlayTrackAtIndex(currentTrack);
    }

    public void PlayPrevious()
    {
        sounds[currentTrack].source.Stop();
        currentTrack--;
        if (currentTrack < 0)
        {
            currentTrack = sounds.Count - 1;
        }
        PlayTrackAtIndex(currentTrack);
    }

    public void PlayTrackAtIndex(int i)
    {
        currentTrack = i;
        print(currentTrack);
        GetComponent<AudioSource>().clip = sounds[currentTrack].clip;
        sounds[currentTrack].source.Play();
        
    }

    public void VolumnUp()
    {
        sounds[currentTrack].source.volume += 0.10f;
        if (sounds[currentTrack].source.volume > 1)
        {
            sounds[currentTrack].source.volume = 1;
        }
    }

    public void VolumnDown()
    {
        sounds[currentTrack].source.volume -= 0.10f;
        if (sounds[currentTrack].source.volume < 0)
        {
            sounds[currentTrack].source.volume = 0;
        }
    }

    public float getVolumne()
    {
        return sounds[currentTrack].source.volume;
    }

    public string getName()
    {
        return sounds[currentTrack].clip.name;
    }

    public void AddSong(AudioClip song)
    {
        Sound s = new Sound();
        s.source = gameObject.GetComponent<AudioSource>();
        s.clip = song;
        s.volumne = 0.5f;
        sounds.Add(s);
    }
}
