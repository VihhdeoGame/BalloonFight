using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private TMP_Text roomName;
    [SerializeField]
    private PlayerListingsMenu playerListingsMenu;
    [SerializeField]
    private LeaveRoomMenu leaveRoomMenu;
    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
        playerListingsMenu.FirstInitialize(_canvases);
        leaveRoomMenu.FirstInitialize(_canvases);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        roomName.text = PhotonNetwork.CurrentRoom.Name;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
