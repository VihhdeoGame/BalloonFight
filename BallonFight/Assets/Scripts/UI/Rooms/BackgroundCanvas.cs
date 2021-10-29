using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

//Class responsible to organize the canvas 
public class BackgroundCanvas : MonoBehaviourPunCallbacks
{
    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
    }
    public override void OnJoinedLobby()
    {
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
