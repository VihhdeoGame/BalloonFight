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
        SceneManager.LoadScene("Main Menu");
        Debug.Log(string.Concat("Welcome",PhotonNetwork.LocalPlayer.NickName));
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log(string.Concat("Disconect from server", cause.ToString()));
    }
}
