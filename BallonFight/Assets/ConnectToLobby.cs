using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ConnectToLobby : MonoBehaviourPunCallbacks
{
    public void OnClick_ConnectToLobby()
    {
        Debug.Log("Connecting to Lobby...");
        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Success, Entering lobby");
    }
}
