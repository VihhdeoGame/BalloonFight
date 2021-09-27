using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class StartGameMenu : MonoBehaviourPunCallbacks
{
    public override void OnEnable()
    {
        base.OnEnable();
        isMaster();
    }
    
    private void isMaster(){ gameObject.SetActive(PhotonNetwork.IsMasterClient); }
    public void OnClick_StarGame()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        PhotonNetwork.LoadLevel("Gameplay");
    }

}
