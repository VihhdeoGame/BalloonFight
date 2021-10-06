using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
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
    public void AddToScores(int player)
    {
        this.photonView.RPC("RPC_SendScore",RpcTarget.All,player);
        if(scores.Count == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            for (int i = 0; i < scores.Count; i++)
            {
                numbers[i].SetActive(true);
                players[i].SetActive(true);
                playersText[i].text = PhotonNetwork.CurrentRoom.GetPlayer(scores.Peek()).NickName;
                players[i].GetComponent<Image>().color = GameManager.PlayerManager.SetColor(scores.Pop());
            }
            canvases.VictoryScreenCanvas.Show();
        }
    }
    [PunRPC]
    void RPC_SendScore(int _player)
    {
        scores.Push(_player);
    } 
}
