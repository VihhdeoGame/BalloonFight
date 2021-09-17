using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    
    void Start() 
    {
        Debug.Log("Connecting to Server...");
        PhotonNetwork.NickName = GameManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = GameManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Success, Connecting to Lobby");
        Debug.Log(string.Concat("Welcome",PhotonNetwork.LocalPlayer.NickName));
        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log(string.Concat("Disconect from server", cause.ToString()));
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Success, Entering lobby");
        SceneManager.LoadScene("Main Menu");
    }
}
