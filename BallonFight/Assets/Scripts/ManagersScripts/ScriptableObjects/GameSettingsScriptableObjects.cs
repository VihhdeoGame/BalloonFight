using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettingsData", menuName = "ScriptableObjects/GameSettingsData")]
public class GameSettingsScriptableObjects : ScriptableObject
{
    private string gameVersion = "0.0.0";
    public string GameVersion { get { return gameVersion; } set { this.gameVersion = value;} }
    [SerializeField]
    private string nickName;
    public string NickName 
    {
        get 
        { 
            int value = Random.Range(0,9999);
            return string.Concat(nickName,value.ToString());
        } 
    }
    
    
}
