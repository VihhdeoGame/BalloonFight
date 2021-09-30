using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class used to play music
public class MusicPlayer : MonoBehaviour
{
    AudioSource musicPlayer;
    [SerializeField]
    string musicName;
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        PlayMusic(musicName);
        ChangeVolume();
    }
    void PlayMusic(string musicName)
    {
        for (int i = 0; i <  GameManager.MusicManager.musics.Length; i++)
        {
            if(GameManager.MusicManager.musics[i].name.Equals(musicName))
            {
                musicPlayer.clip = GameManager.MusicManager.musics[i].audio;
                break;
            }
        }
        musicPlayer.Play();
    }
    void ChangeVolume()
    {
        musicPlayer.volume = GameManager.MusicManager.volume/100;
    }
}
