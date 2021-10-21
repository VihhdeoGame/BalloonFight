using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

//Class responsible for major callbacks inLobby, every room update gets stored in the dict cachedRoomList
public class LobbyManager : MonoBehaviourPunCallbacks
{
    private Dictionary<string, RoomInfo> cachedRoomList = new Dictionary<string, RoomInfo>();
    public Dictionary<string, RoomInfo> CachedRoomList {get {return cachedRoomList; } }
    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
    }
    public override void OnEnable()
    {
        base.OnEnable();
        ConnectMaster();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connecting to Lobby...");
        PhotonNetwork.JoinLobby(GameManager.Lobby);    
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        cachedRoomList.Clear();
        Debug.Log(string.Concat("Disconect from server", cause.ToString()));
        GameManager.SceneManager.LoadScene("Main Menu");
    }
    public override void OnJoinedLobby()
    {
        cachedRoomList.Clear();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateCachedRoomList(roomList);
    }
    public override void OnLeftLobby()
    {
        cachedRoomList.Clear();
    }
    public override void OnJoinedRoom()
    {
        cachedRoomList.Clear();
    }
    public override void OnLeftRoom()
    {
        ConnectMaster();        
    }
    private void ConnectMaster()
    {
        if(!PhotonNetwork.IsConnected)
        {
            Debug.Log("Connecting to Server...");
            PhotonNetwork.SendRate = 240;
            PhotonNetwork.SerializationRate = 240;
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.NickName = GameManager.GameSettings.NickName;
            PhotonNetwork.GameVersion = GameManager.GameSettings.GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    private void UpdateCachedRoomList(List<RoomInfo> _roomList)
    {
        for (int i = 0; i < _roomList.Count; i++)
        {
            RoomInfo info = _roomList[i];
            if(info.RemovedFromList)
            {
                cachedRoomList.Remove(info.Name);
            }
            else
            {
                cachedRoomList[info.Name] = info;
            }
        }
    }
}
