using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField]GameObject lifePrefab;
    List<GameObject> lifeArray;
    PlayerGeneralManager[] players;
    int currentLives;
    private void Awake()
    {
        players = FindObjectsOfType<PlayerGeneralManager>();
        lifeArray = new List<GameObject>();
        DisplayHearts(players[PhotonNetwork.LocalPlayer.ActorNumber-1].currentLives);
    }
    void DisplayHearts(int maxLives)
    {
        for (int i = 0; i < maxLives; i++)
        {
            lifeArray.Add(Instantiate(lifePrefab,transform));
            lifeArray[i].GetComponent<Image>().color = GameManager.PlayerManager.playerColors[PhotonNetwork.LocalPlayer.ActorNumber-1];
        }
        currentLives = maxLives;
    }
    public void UpdateHearts(int lives)
    {
        if(lives > currentLives)
        {
            for (int i = 0; i < lifeArray.Count; i++)
            {
                lifeArray[i].SetActive(true);
                currentLives = lives;                
            }
        }
        if(currentLives > lives)
        {
            lifeArray[currentLives-1].SetActive(false);
            currentLives = lives;
        }
    }
}
