using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

//Class responsible to join rooms 
public class JoinRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField roomName;
    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
    }
    public void OnClick_JoinRoom()
    {
        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby(GameManager.Lobby);
        PhotonNetwork.JoinRoom(roomName.text.ToUpper());
    }

    public override void OnJoinedRoom()
    {
        roomName.text = "";
        Debug.Log("Joined room successfully");
        Debug.Log(string.Concat("Room Name: ",PhotonNetwork.CurrentRoom.Name));
        roomCanvases.CurrentRoomCanvas.Show();
        roomCanvases.CreateOrJoinRoomCanvas.Hide();
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        roomName.text = "";
        Debug.Log(string.Concat("Room Join failed: ",message));
        PhotonNetwork.JoinLobby(GameManager.Lobby);
    }
}
