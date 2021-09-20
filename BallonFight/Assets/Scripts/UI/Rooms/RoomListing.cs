using System.Collections;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    public RoomInfo RoomInfo{get; private set;}
    public void SetRoomInfo(RoomInfo _roomInfo)
    {
        RoomInfo = _roomInfo;
       text.text = string.Concat(_roomInfo.MaxPlayers,", ",_roomInfo.Name);
    }
    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
}
