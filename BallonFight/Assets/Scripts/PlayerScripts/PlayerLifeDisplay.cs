using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerLifeDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField]GameObject lifePrefab;
    List<GameObject> lifeArray;
    PlayerGeneralManager[] players;
    int currentLives;
    public override void OnEnable() 
    {
        base.OnEnable();
        players = FindObjectsOfType<PlayerGeneralManager>();
        lifeArray = new List<GameObject>();
        DisplayHearts(players[PhotonNetwork.LocalPlayer.ActorNumber-1].currentLives);
    }
    void DisplayHearts(int maxLives)
    {
        for (int i = 0; i < maxLives; i++)
        {
            lifeArray.Add(Instantiate(lifePrefab,transform));
        }
        currentLives = maxLives;
    }
    public void UpdateHearts(int lives)
    {
        if(currentLives > lives)
        {
            lifeArray[currentLives-1].SetActive(false);
            currentLives = lives;
        }
    }
}
