using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "MusicSettingsData", menuName = "ScriptableObjects/MusicSettingsData")]
public class MusicSettingsScriptableObjects : ScriptableObject
{
    [Header("Master Volume")]
    [Range(0,100)]public float volume;
   
    [Header("Music List")]
    public MusicSettingData[] musics;

    [Header("SFX List")]
    public MusicSettingData[] sfxs;
}

[Serializable]
public class MusicSettingData
{
    public string name;
    public AudioClip audio;
}