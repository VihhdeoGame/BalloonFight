using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class responsible to organize the canvas
public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu createRoomMenu;
    [SerializeField]
    private JoinRoomMenu joinRoomMenu;
    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
        createRoomMenu.FirstInitialize(_canvases);
        joinRoomMenu.FirstInitialize(_canvases);
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
