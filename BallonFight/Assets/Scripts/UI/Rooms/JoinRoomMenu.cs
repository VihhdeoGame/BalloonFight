using System.Collections;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class JoinRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text roomName;
    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
    }
    public void OnClick_JoinRoom()
    {
        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby(GameManager.Lobby);

        Hashtable RoomCustomPropriety = new Hashtable();
        RoomCustomPropriety.Add("Name", roomName.text);      
        PhotonNetwork.JoinRandomRoom(RoomCustomPropriety,0);
    }

    public override void OnJoinedRoom()
    {
        roomName.text = "";
        Debug.Log("Joined room successfully", this);
        Debug.Log(string.Concat("Room Name ",PhotonNetwork.CurrentRoom.Name));
        roomCanvases.CurrentRoomCanvas.Show();
        roomCanvases.CreateOrJoinRoomCanvas.Hide();
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log(string.Concat("Room creation failed: ",message), this);
    }
}
