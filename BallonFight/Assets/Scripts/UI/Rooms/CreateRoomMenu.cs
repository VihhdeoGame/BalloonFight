using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text roomName;
    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
    }
    public void OnClick_CreateRoom()
    {
        if(!PhotonNetwork.IsConnected)
            return;
        RoomOptions _options = new RoomOptions();
        _options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(roomName.text, _options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room successfully", this);
        roomCanvases.CurrentRoomCanvas.Show();
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log(string.Concat("Room creation failed: ",message), this);
    }
    
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log(string.Concat("couldn't enter room ",message));
    }
}
