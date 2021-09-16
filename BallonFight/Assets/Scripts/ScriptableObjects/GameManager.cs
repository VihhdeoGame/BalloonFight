using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManagerData", menuName = "ScriptableObjects/GameManager")]
public class GameManager : SingletonScriptableObject<GameManager>
{
    [SerializeField]
    public PlayerSettingsScriptableObjects playerManager;
    [SerializeField]
    public MusicSettingsScriptableObjects musicManger;
    public static PlayerSettingsScriptableObjects PlayerManager{ get { return Instance.playerManager; } }
    public static MusicSettingsScriptableObjects MusicManager { get { return Instance.musicManger;} }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void FirstInitialize()
    {
        Debug.Log("This message will output before Awake.");
    }

    
}
