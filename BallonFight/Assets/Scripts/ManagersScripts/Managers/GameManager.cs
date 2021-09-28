using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

//Singleton responsible to get the settings for the game
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
    [SerializeField]
    private SceneManagerScriptableObjects sceneManager;
    [SerializeField]
    private List<NetworkedPrefab> networkedPrefabs = new List<NetworkedPrefab>();
    public static SceneManagerScriptableObjects SceneManager{ get { return Instance.sceneManager; } }
    public static NetworkLobbySettingsScriptableObjects NetworkLobbyManager { get { return Instance.networkLobbyManager; } }
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
    //Function responsible to create instances though the network
    public static GameObject NetworkInstantiante(GameObject obj, Vector3 position, Quaternion rotation)
    {
        foreach (NetworkedPrefab _networkedPrefab in Instance.networkedPrefabs)
        {
            if(_networkedPrefab.Prefab == obj)
            {
                if(_networkedPrefab.Path != string.Empty)
                {
                    GameObject result =PhotonNetwork.Instantiate(_networkedPrefab.Path, position, rotation);
                    return result;
                }
                else
                {
                    Debug.LogError(string.Concat("Path is empty for gameobject ", _networkedPrefab.Prefab));
                    return null;
                }
            }            
        }
        return null;
    }
    //Fuction responsible to prepare the prefabs for photon network
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void PopulateNetworkedPrefabs()
    {
#if UNITY_EDITOR       
        Instance.networkedPrefabs.Clear();
        GameObject[] results = Resources.LoadAll<GameObject>("");
        for (int i = 0; i < results.Length; i++)
        {
            if(results[i].GetComponent<PhotonView>() != null)
            {
                string path = AssetDatabase.GetAssetPath(results[i]);
                Instance.networkedPrefabs.Add(new NetworkedPrefab(results[i], path));
            }    
        }
#endif
    }
}
