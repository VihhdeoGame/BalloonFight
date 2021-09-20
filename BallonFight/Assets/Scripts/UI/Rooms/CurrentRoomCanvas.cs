using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
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
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
