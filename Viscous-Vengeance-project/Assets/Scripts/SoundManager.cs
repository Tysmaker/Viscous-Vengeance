using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    //Gets refernece to see so we can check the current build index and play the music accordingly.
    Scene scene;
  
    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        //This switch is going to check our scene buildindex and play the right music according to the level
        switch (scene.buildIndex)
        {
            case 0:
                    Play("MenuMusic");             
                break;
            case 1: Play("BG_Level1");
                break;
            case 2: Play("BG_Level2");
                break;
            case 3: Play("BG_Level3");
                break;
        }    
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        sound.source.Play();
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        sound.source.Stop();
    }

    public void Pause(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        sound.source.Pause();
    }
}
