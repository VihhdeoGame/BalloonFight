using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OthersLifeDisplay : MonoBehaviour
{
    [SerializeField]
    OtherLifeDisplay prefab;
    PlayerGeneralManager[] players;
    public Dictionary<int, OtherLifeDisplay> othersLives = new Dictionary<int, OtherLifeDisplay>();
    private void Awake()
    {   
        players = FindObjectsOfType<PlayerGeneralManager>();
        for (int i = 0; i < players.Length; i++)
        {
            if(players[i].playerNumber != ((PhotonNetwork.LocalPlayer.ActorNumber-1)%4)+1)
            {
                OtherLifeDisplay _other = Instantiate(prefab,transform);
                othersLives.Add(players[i].playerNumber, _other);
                othersLives[players[i].playerNumber].DisplayHearts(players[i].currentLives,players[i].playerNumber);
            }
        }
    }
}
