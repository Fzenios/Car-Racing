using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class SoundsScr : MonoBehaviour
{
    public Sound[] Sounds;
    public AudioMixerGroup mixerGroup, Enginegroup, MusicGroup;
    public AllData allData;
    public PlayerControls playerControls;

    void Awake() 
    {
        foreach (Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.loop = false;
            s.source.clip = s.Clip; 
            s.source.outputAudioMixerGroup = mixerGroup; 
        }
    }
    void Start() 
    {
        MuteCheck();
    }

    public void IntroSong()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Intro");
        if(s != null)
        {
            s.source.outputAudioMixerGroup = MusicGroup; 
            s.source.Play();
            s.source.loop = true;
        }    
    }

    public void MainGameSong()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Main");
        if(s != null)
        {
            s.source.outputAudioMixerGroup = MusicGroup; 
            s.source.Play();
            s.source.loop = true;
        }    
    }
    public void Engine(string Play)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Engine");
        if(s != null)
        {
            s.source.outputAudioMixerGroup = Enginegroup; 
            s.source.volume = 0.4f;
            if(Play == "Play")
            {
                s.source.Play();
                s.source.loop = true;
                s.source.pitch = 1f;
            }
            else if (Play == "Stop")
                s.source.Stop();
            else if (Play == "Pause")
                s.source.Pause();
            else if(Play == "UnPause")
                s.source.UnPause();
        }
    }
    public void StartRace(string Play)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "StartRace");
        if(s != null)
        {
            s.source.outputAudioMixerGroup = MusicGroup; 
            if(Play == "Play")
                s.source.Play();
            else if (Play == "Stop")
                s.source.Stop();
            else if (Play == "Pause")
                s.source.Pause();
            else if(Play == "UnPause")
                s.source.UnPause();
        }    
    }

    public void MuteMusicBtn()
    {  
        allData.MuteMus =! allData.MuteMus;        
        if(allData.MuteMus)
            MusicGroup.audioMixer.SetFloat("VolumeMus",-80);
        else
            MusicGroup.audioMixer.SetFloat("VolumeMus",0);
    }
    public void MuteEngBtn()
    {  
        allData.MuteEng =! allData.MuteEng;        
        if(allData.MuteEng)
            MusicGroup.audioMixer.SetFloat("VolumeEng",-80);
        else
            MusicGroup.audioMixer.SetFloat("VolumeEng",0);
    }
    void MuteCheck()
    {
        if(allData.MuteMus)
            MusicGroup.audioMixer.SetFloat("VolumeMus",-80);
        else
            MusicGroup.audioMixer.SetFloat("VolumeMus",0);
         
        if(allData.MuteEng)
            MusicGroup.audioMixer.SetFloat("VolumeEng",-80);
        else
            MusicGroup.audioMixer.SetFloat("VolumeEng",0);
    }
}
