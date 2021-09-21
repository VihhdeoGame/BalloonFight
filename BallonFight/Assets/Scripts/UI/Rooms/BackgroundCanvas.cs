using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
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
        Debug.Log("Connecting to Lobby...");
        PhotonNetwork.JoinLobby(GameManager.Lobby);
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Success, Entering lobby");
        roomCanvases.CreateOrJoinRoomCanvas.Show();
        roomCanvases.BackgroundCanvas.Hide();
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
