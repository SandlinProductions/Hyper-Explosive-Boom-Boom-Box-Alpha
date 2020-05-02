﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
    //public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.
    public float masterVolume;

    private void Start()
    {
        masterVolume = musicSource.volume;
    }

    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();
    }


    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(params AudioClip[] clips)
    {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, clips.Length);

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        efxSource.pitch = randomPitch;

        //Set the clip to the clip at our randomly chosen index.
        efxSource.clip = clips[randomIndex];

        //Play the clip.
        efxSource.Play();
    }
    private void Update()
    {
        if (PauseMenu.GameIsPaused == true)
        {
            musicSource.pitch = .5f;
            musicSource.volume = masterVolume/2;
        }
        if (PauseMenu.GameIsPaused == false)
        {
            musicSource.pitch = 1f;
            musicSource.volume = masterVolume;
        }
        if(Time.timeScale <1)
        {
            musicSource.pitch = .5f;
            musicSource.volume = masterVolume/2;
        }
        else if (Time.timeScale ==1f)
        {
            musicSource.pitch = 1f;
            musicSource.volume = masterVolume;
        }
    }
}
