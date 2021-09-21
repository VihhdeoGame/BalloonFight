using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ConnectToLobby : MonoBehaviourPunCallbacks
{
    public override void OnEnable()
    {
        base.OnEnable();
        Debug.Log("Connecting to Lobby...");
        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby(GameManager.Lobby);
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Success, Entering lobby");
    }
}
