using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviourPunCallbacks
{
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
    private void Update()
    {
        if(playerManagers == null)
            UpdatePlayerList();
        if(!canvases.VictoryScreenCanvas.isActiveAndEnabled)
            CheckVictory();
        else
            CheckIsReady();   
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
    public void AddToScores(int player)
    {
        this.photonView.RPC("RPC_SendScore",RpcTarget.All,player);
    }
    [PunRPC]
    void RPC_SendScore(int _player)
    {
        scores.Push(_player);
    }
    void CheckVictory()
    {
        if(scores.Count == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
            {
                numbers[i].SetActive(true);
                players[i].SetActive(true);
                playersText[i].text = PhotonNetwork.CurrentRoom.GetPlayer(scores.Peek()).NickName;
                players[i].GetComponent<Image>().color = GameManager.PlayerManager.SetColor(scores.Pop());
            }
            canvases.VictoryScreenCanvas.Show();
            canvases.GameplayUICanvas.Hide();
        }
    }
    public void OnClick_LeaveRoom()
    {
        scores.Clear();
        playerManagers = null;
        PhotonNetwork.Disconnect();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        GameManager.SceneManager.LoadScene("Main Menu");        
    }

}
