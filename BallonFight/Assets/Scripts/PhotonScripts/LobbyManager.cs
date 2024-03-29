﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

//Class responsible for major callbacks inLobby, every room update gets stored in the dict cachedRoomList
public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    StartGameMenu startGameMenu;
    private Dictionary<string, RoomInfo> cachedRoomList = new Dictionary<string, RoomInfo>();
    public Dictionary<string, RoomInfo> CachedRoomList {get {return cachedRoomList; } }
    private RoomCanvases roomCanvases;
    private float ping; 
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
        PhotonNetwork.JoinLobby(GameManager.Lobby);    
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        cachedRoomList.Clear();
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
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        startGameMenu.StopAllCoroutines();
        startGameMenu.isMaster();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        startGameMenu.isMaster();
    }
    private void ConnectMaster()
    {
        if(!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.SendRate = 30;
            PhotonNetwork.SerializationRate = 10;
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
