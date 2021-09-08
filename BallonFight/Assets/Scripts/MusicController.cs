using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField][Range(0,100)]float volume;
    [SerializeField]AudioClip[] musics;
    AudioSource musicPlayer;
    void Awake() 
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Music");
        musicPlayer = obj.GetComponent<AudioSource>();
        ChangeMusic(0);
        ChangeVolume();
    }
    #if UNITY_EDITOR
        void Update() 
        {
            ChangeVolume();
            if(Input.GetKeyDown(KeyCode.Z))
                ChangeMusic(1);
        }
    #endif
    public void ChangeVolume()
    {
        musicPlayer.volume = volume/100;
    }
    public void ChangeMusic(int musicNumber)
    {
        if(musicPlayer.isPlaying)
        {
            musicPlayer.Stop();
        }
        musicPlayer.clip = musics[musicNumber];
        musicPlayer.Play();
    }
}
