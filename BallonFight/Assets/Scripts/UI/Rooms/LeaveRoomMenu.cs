using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

//Class responsible to exit rooms
public class LeaveRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject startButton,countdownTimer;
    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
    }
    public void OnClick_LeaveRoom()
    {
        StopAllCoroutines();
        PhotonNetwork.LeaveRoom(true);
        startButton.SetActive(true);
        countdownTimer.SetActive(false);
        roomCanvases.CurrentRoomCanvas.Hide();
        roomCanvases.BackgroundCanvas.Show();
    }
}
