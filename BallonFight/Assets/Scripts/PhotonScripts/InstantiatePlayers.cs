using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

//Class responsible for player instances though Photon
public class InstantiatePlayers : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    PhotonView[] spawnPoints; 
    private void Awake() 
    {
        GameManager.NetworkInstantiante(prefab, spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber - 1].transform.position, Quaternion.identity);        
    }
}
