using System.Collections;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    private string roomName;
    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
    }
    public void OnClick_CreateRoom()
    {
        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby(GameManager.Lobby);
        RoomOptions _options = new RoomOptions();
        _options.MaxPlayers = 4;
        do
        {
            roomName = CreateRandomName(5);
        } while(!PhotonNetwork.GetCustomRoomList(GameManager.Lobby,roomName));
        
        Hashtable RoomCustomPropriety = new Hashtable();
        RoomCustomPropriety.Add(roomName, 0);
        
        PhotonNetwork.CreateRoom(roomName, _options,GameManager.Lobby);
        roomCanvases.BackgroundCanvas.Show();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room successfully", this);
        Debug.Log(string.Concat("Room Name ",PhotonNetwork.CurrentRoom.Name));
        roomCanvases.CurrentRoomCanvas.Show();
        roomCanvases.CreateOrJoinRoomCanvas.Hide();
        roomCanvases.BackgroundCanvas.Hide();
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log(string.Concat("Room creation failed: ",message), this);
        roomCanvases.BackgroundCanvas.Hide();
    }
    private string CreateRandomName(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        StringBuilder name = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            name.Append(chars[Random.Range(0,36)]);
        }
        return name.ToString();
    }
}
