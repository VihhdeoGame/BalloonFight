using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

//Class responsible for player instances though Photon
public class InstantiatePlayers : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    PhotonView[] spawnPoints;
    List<PlayerGeneralManager> players = new List<PlayerGeneralManager>(); 
    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);                
    }
    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);        
    }
    private void Awake() 
    {
        GameManager.NetworkInstantiante(prefab, spawnPoints[(PhotonNetwork.LocalPlayer.ActorNumber-1)%4].transform.position, Quaternion.identity);        
    }
}
