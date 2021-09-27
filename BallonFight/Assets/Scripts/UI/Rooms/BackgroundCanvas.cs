using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class BackgroundCanvas : MonoBehaviourPunCallbacks
{
    private RoomCanvases roomCanvases;
    
    public Dictionary<string, RoomInfo> cachedRoomList = new Dictionary<string, RoomInfo>();
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
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
    public override void OnEnable()
    {
        base.OnEnable();
        if(!PhotonNetwork.IsConnected)
        {
            Debug.Log("Connecting to Server...");
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.NickName = GameManager.GameSettings.NickName;
            PhotonNetwork.GameVersion = GameManager.GameSettings.GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connecting to Lobby...");
        PhotonNetwork.JoinLobby(GameManager.Lobby);    
    }
    public override void OnJoinedLobby()
    {
        cachedRoomList.Clear();
        Debug.Log("Success, Entering lobby");
        roomCanvases.CreateOrJoinRoomCanvas.Show();
        roomCanvases.BackgroundCanvas.Hide();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateCachedRoomList(roomList);
    }
    public override void OnLeftLobby()
    {
        cachedRoomList.Clear();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        cachedRoomList.Clear();
        Debug.Log(string.Concat("Disconect from server", cause.ToString()));
        GameManager.SceneManager.LoadScene("Main Menu");
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
