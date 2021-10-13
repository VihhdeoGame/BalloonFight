using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviourPun,IOnEventCallback
{
    private const byte SEND_SCORE_EVENT = 100;
    [SerializeField]
    Fade fade;
    [SerializeField]
    GameplayCanvases canvases;
    Stack<int> scores = new Stack<int>();
    public Stack<int> Scores{get {return scores; } }
    [SerializeField]
    GameObject[] numbers;
    [SerializeField]
    GameObject[] players;
    [SerializeField]
    TMP_Text[] playersText;
    PlayerGeneralManager[] playerManagers;
    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);        
    }
    private void OnDisable() 
    {
        PhotonNetwork.RemoveCallbackTarget(this);        
    }
    private void Update()
    {
       if(!canvases.VictoryScreenCanvas.isActiveAndEnabled)
            CheckVictory();   
    }
    void UpdatePlayerList()
    {
        playerManagers = FindObjectsOfType<PlayerGeneralManager>();
    }
    public void OnClick_SetReady()
    {
        UpdatePlayerList();
        for (int i = 0; i < playerManagers.Length; i++)
        {
            if(playerManagers[i].playerNumber == PhotonNetwork.LocalPlayer.ActorNumber)
            {

                playerManagers[i].View.RPC("RPC_SetReady", RpcTarget.All, true);
            }
        }
    }
    
    void CheckIsReady()
    {
        if(PhotonNetwork.IsConnected)
        {
            UpdatePlayerList();        
            if(playerManagers.Length == PhotonNetwork.CurrentRoom.PlayerCount)
            {
                bool _isReady = true;
                for (int i = 0; i < playerManagers.Length; i++)
                {
                    if(!playerManagers[i].isReady)
                    {
                        _isReady = false;
                        break;
                    }                
                }
                if(_isReady)
                {
                    //get gameplay to work again here
                    Debug.Log("Wow, você esta jogando de novo, such game, much fun, so good");
                    for (int i = 0; i < playerManagers.Length; i++)
                    {
                        if(playerManagers[i].playerNumber == PhotonNetwork.LocalPlayer.ActorNumber)
                        {
                            playerManagers[i].View.RPC("RPC_ResetValues", RpcTarget.All);
                            canvases.VictoryScreenCanvas.Hide();
                            canvases.GameplayUICanvas.Show();
                        }
                    }
                }
            }
        }
    }
    void CheckVictory()
    {
        if(scores.Count == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
            {
                numbers[i].SetActive(true);
                players[i].SetActive(true);
                int _score = scores.Pop();
                playersText[i].text = PhotonNetwork.CurrentRoom.GetPlayer(_score).NickName;
                players[i].GetComponent<Image>().color = GameManager.PlayerManager.SetColor(_score);
            }
            canvases.VictoryScreenCanvas.Show();
            canvases.GameplayUICanvas.Hide();
        }
    }
    public void OnClick_LeaveRoom()
    {
        fade.FadeIn();
        PhotonNetwork.Disconnect();
    }
    //public override void OnDisconnected(DisconnectCause cause)
    //{
    //    GameManager.SceneManager.LoadScene("Main Menu");        
    //}

    public void OnEvent(EventData photonEvent)
    {
        if(photonEvent.Code == SEND_SCORE_EVENT)
        {
            object[] datas = (object[])photonEvent.CustomData;
            int _score = (int)datas[0];
            scores.Push(_score);
        }
    }
}
