using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{
    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
    }
    public void OnClick_LeaveRoom()
    {
       PhotonNetwork.LeaveRoom(true);
       roomCanvases.CurrentRoomCanvas.Hide();
    }
}
