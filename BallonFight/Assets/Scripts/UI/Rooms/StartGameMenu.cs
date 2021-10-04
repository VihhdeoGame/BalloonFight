using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

//Class used to close a room and start the game
public class StartGameMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]GameObject countdown;
    [SerializeField] TMP_Text countdownDisplay;
    [SerializeField] int countdownTime;
    PhotonView view;
    public override void OnEnable()
    {
        view = GetComponent<PhotonView>();
        base.OnEnable();
        isMaster();
    }
    private void isMaster(){ gameObject.SetActive(PhotonNetwork.IsMasterClient); }
    public void OnClick_StarGame()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        gameObject.SetActive(false);
        view.RPC("RPC_CountdownToStart",RpcTarget.All);
    }

    [PunRPC]
    IEnumerator RPC_CountdownToStart()
    {
        countdown.SetActive(true);
        while(countdownTime > 0)
        {

            countdownDisplay.text = string.Concat("The game will start in: ",countdownTime.ToString());
            Debug.Log(countdownTime.ToString());

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }
        if(PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel("Gameplay");    
    }

}
