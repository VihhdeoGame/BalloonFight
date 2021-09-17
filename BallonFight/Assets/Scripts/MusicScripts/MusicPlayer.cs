using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource musicPlayer;
    [SerializeField]
    string musicName;
    void Start()
    {/*
        musicPlayer = GetComponent<AudioSource>();
        PlayMusic(musicName);
        ChangeVolume();
    */}
    void PlayMusic(string musicName)
    { /*
        for (int i = 0; i <  GameManager.MusicManger.musics.Length; i++)
        {
            if(GameManager.MusicManger.musics[i].name.Equals(musicName))
            {
                musicPlayer.clip = GameManager.MusicManger.musics[i].audio;
                break;
            }
        }
        musicPlayer.Play();
    */}
    void ChangeVolume()
    {/*
        musicPlayer.volume = GameManager.MusicManger.volume/100;
    */
    }
}
