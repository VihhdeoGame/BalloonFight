using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class BackgroundCanvas : MonoBehaviourPunCallbacks
{
    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
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
        Debug.Log("Success, Entering lobby");
        roomCanvases.CreateOrJoinRoomCanvas.Show();
        roomCanvases.BackgroundCanvas.Hide();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
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
