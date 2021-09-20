using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu createRoomMenu;
    [SerializeField]
    private RoomListingsMenu roomListingsMenu;
    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
        createRoomMenu.FirstInitialize(_canvases);
        roomListingsMenu.FirstInitialize(_canvases);
    }
}
