using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

//Class responsible to join rooms 
public class JoinRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField nickNameInput;
    [SerializeField]
    private TMP_InputField roomName;
    [SerializeField]
    private TMP_Text errorMessageText;
    private RoomCanvases roomCanvases;
    public void FirstInitialize(RoomCanvases _canvases)
    {
        roomCanvases = _canvases;
    }
    public void OnClick_JoinRoom()
    {
        if(nickNameInput.text != "")
        {
            PhotonNetwork.NickName = nickNameInput.text;
        }
        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby(GameManager.Lobby);
        if(!roomName.text.Equals(""))
            PhotonNetwork.JoinRoom(roomName.text.ToUpper());
        else
            errorMessageText.text = string.Concat("Enter room code or create a new room!");
    }

    public override void OnJoinedRoom()
    {
        roomName.text = "";
        roomCanvases.CurrentRoomCanvas.Show();
        roomCanvases.CreateOrJoinRoomCanvas.Hide();
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        roomName.text = "";
        errorMessageText.text = string.Concat("Failed to join room!\nReason: ",message);
        PhotonNetwork.JoinLobby(GameManager.Lobby);
    }
}
