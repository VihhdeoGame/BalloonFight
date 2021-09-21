using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManagerData", menuName = "ScriptableObjects/GameManager")]
public class GameManager : SingletonScriptableObject<GameManager>
{
    
    [SerializeField]
    private GameSettingsScriptableObjects gameSettings;
    
    [SerializeField]
    private PlayerSettingsScriptableObjects playerManager;
    
    [SerializeField]
    private MusicSettingsScriptableObjects musicManger;
    [SerializeField]
    private NetworkLobbySettingsScriptableObjects networkLobbyManager;
    public static NetworkLobbySettingsScriptableObjects NetworkLobbyManager {get { return Instance.networkLobbyManager; } }
    public static PlayerSettingsScriptableObjects PlayerManager{ get { return Instance.playerManager; } }
    public static MusicSettingsScriptableObjects MusicManager { get { return Instance.musicManger; } }
    public static GameSettingsScriptableObjects GameSettings { get { return Instance.gameSettings; } }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void FirstInitialize()
    {
        Debug.Log("This message will output before Awake.");
    }
    public static TypedLobby Lobby
    {
        get
        {
            TypedLobby lobby = new TypedLobby(NetworkLobbyManager.lobbyName, NetworkLobbyManager.lobbyType);
            return lobby;
        }
    }
}
