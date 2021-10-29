using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

//Class used to close a room and start the game
public class StartGameMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]GameObject countdown,startButton;
    [SerializeField] TMP_Text countdownDisplay;
    [SerializeField] int countdownTime;
    PhotonView view;
    public override void OnEnable()
    {
        view = GetComponent<PhotonView>();
        base.OnEnable();
        isMaster();
    }
    public void isMaster(){ startButton.SetActive(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount>1); }
    public void OnClick_StarGame()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        view.RPC("RPC_CountdownToStart",RpcTarget.Others);
        StartCoroutine(CountdownToStart());
        startButton.SetActive(false);
    }

    [PunRPC]
    void RPC_CountdownToStart()
    {
        StartCoroutine(CountdownToStart());
    }
    IEnumerator CountdownToStart()
    {
        int _countdownTime = countdownTime;
        countdown.SetActive(true);
        while(_countdownTime > 0)
        {

            countdownDisplay.text = string.Concat("The game will start in: ",_countdownTime.ToString());

            yield return new WaitForSeconds(1f);

            _countdownTime--;
        }
        if(PhotonNetwork.IsMasterClient && _countdownTime == 0)
            PhotonNetwork.LoadLevel("Gameplay");    
    }

}
