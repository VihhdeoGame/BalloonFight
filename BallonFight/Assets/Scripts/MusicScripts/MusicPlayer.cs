using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        for (int i = 0; i <  GameManager.Instance.musicManger.musics.Length; i++)
        {
            if(GameManager.Instance.musicManger.musics[i].name.Equals(musicName))
            {
                musicPlayer.clip = GameManager.Instance.musicManger.musics[i].audio;
                break;
            }
        }
        musicPlayer.Play();
    }
    void ChangeVolume()
    {
        musicPlayer.volume = GameManager.Instance.musicManger.volume/100;
    }
}
