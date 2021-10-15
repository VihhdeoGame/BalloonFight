using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameplayLoadingBackgroundCanvas : MonoBehaviour
{
    private GameplayCanvases gameplayCanvases;
    public void FirstInitialize(GameplayCanvases _canvases)
    {
        gameplayCanvases = _canvases;
    }
    private void Update()
    {
        if(PhotonNetwork.IsConnected)
            GetPlayersReady();
    }
    private void GetPlayersReady()
    {
        PlayerGeneralManager[] _players = FindObjectsOfType<PlayerGeneralManager>();
        if(_players.Length == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            gameplayCanvases.BackgroundCanvas.Hide();
            gameplayCanvases.GameplayUICanvas.Show();
        }
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
