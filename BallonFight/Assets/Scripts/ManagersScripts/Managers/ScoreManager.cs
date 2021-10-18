using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviourPunCallbacks,IOnEventCallback
{
    [SerializeField]
    Fade fade;
    [SerializeField]
    GameplayCanvases canvases;
    Queue<int> scoresReceived = new Queue<int>();
    Stack<int> scores = new Stack<int>();
    public Queue<int> ScoresReceived{get{return scoresReceived;}}
    [SerializeField]
    GameObject[] numbers;
    [SerializeField]
    GameObject[] players;
    [SerializeField]
    TMP_Text[] playersText;
    bool eventSent = false;
    [SerializeField]
    GameObject buttonIsReady;
    [SerializeField]
    GameObject buttonLeaveRoom;
    [SerializeField]
    GameObject playAgainButton;
    Dictionary<int,bool> arePlayersReady = new Dictionary<int,bool>();
    private new void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);        
    }
    private new void OnDisable() 
    {
        PhotonNetwork.RemoveCallbackTarget(this);        
    }
    
    private void Update() 
    {
        if(PhotonNetwork.IsConnected)
        {
            if(scoresReceived.Count == PhotonNetwork.CurrentRoom.PlayerCount && !eventSent)
            {
                object[] datas = new object[PhotonNetwork.CurrentRoom.PlayerCount];
                for (int i = 0; i < datas.Length; i++)
                {
                    datas[i] = scoresReceived.Dequeue();                                
                }
                RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
                PhotonNetwork.RaiseEvent(Const.SEND_LEADERBOARD_EVENT,datas, raiseEventOptions, SendOptions.SendReliable);
                eventSent = true;
            }
            if(PhotonNetwork.IsMasterClient)
            {
                if(buttonIsReady.activeInHierarchy)
                    buttonIsReady.SetActive(false);
                if(CheckIsReady() && !playAgainButton.activeInHierarchy)
                {
                    playAgainButton.SetActive(true);
                }
            }
            if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                buttonIsReady.SetActive(false);
                playAgainButton.SetActive(false);
            }
        }        
    }
    public void OnClick_SetReady()
    {
        object datas = new object[]{true, PhotonNetwork.LocalPlayer.ActorNumber};
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.MasterClient };
        PhotonNetwork.RaiseEvent(Const.SEND_READY_EVENT,datas, raiseEventOptions, SendOptions.SendReliable);
        buttonIsReady.SetActive(false);
        buttonLeaveRoom.SetActive(false);
    }
    public void OnClick_PlayAgain()
    {
        playAgainButton.SetActive(false);
        object datas = null;
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(Const.PLAY_AGAIN_EVENT,datas, raiseEventOptions, SendOptions.SendReliable);
        arePlayersReady.Clear();        
    }
    bool CheckIsReady()
    {
        return(arePlayersReady.Count == PhotonNetwork.CurrentRoom.PlayerCount - 1);
    }
    void CheckVictory()
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
    public void OnClick_LeaveRoom()
    {
        fade.FadeIn();
        PhotonNetwork.Disconnect();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        GameManager.SceneManager.LoadScene("Main Menu");        
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(PhotonNetwork.IsMasterClient && arePlayersReady.ContainsKey(otherPlayer.ActorNumber))
            arePlayersReady.Remove(otherPlayer.ActorNumber);
    }
    public void OnEvent(EventData photonEvent)
    {
        Debug.Log(string.Concat("Event Recived: ",photonEvent.Code.ToString()));
        if(photonEvent.Code == Const.SEND_SCORE_EVENT)
        {
            object[] datas = (object[])photonEvent.CustomData;
            int _score = (int)datas[0];
            Debug.Log(string.Concat("Recebeu player: ",_score.ToString()));
            scoresReceived.Enqueue(_score);
        }
        if(photonEvent.Code == Const.SEND_LEADERBOARD_EVENT)
        {
            object[] datas = (object[])photonEvent.CustomData;
            for (int i = 0; i < datas.Length; i++)
            {
                int _score = (int)datas[i];
                scores.Push(_score);               
            }
            CheckVictory();
        }
        if(photonEvent.Code == Const.SEND_READY_EVENT)
        {
            object[] datas = (object[])photonEvent.CustomData;
            bool isReady = (bool)datas[0];
            int playerID = (int)datas[1];
            arePlayersReady.Add(playerID,isReady);
        }
        if(photonEvent.Code == Const.PLAY_AGAIN_EVENT)
        {
            eventSent = false;
            buttonIsReady.SetActive(true);
            buttonLeaveRoom.SetActive(true);
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i].SetActive(false);
                players[i].SetActive(false);
            }
            canvases.VictoryScreenCanvas.Hide();
            canvases.GameplayUICanvas.Show();
        }
    }
}
