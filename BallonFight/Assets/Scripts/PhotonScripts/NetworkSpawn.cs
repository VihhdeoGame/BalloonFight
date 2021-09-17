using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkSpawn : MonoBehaviour
{
    public GameObject gameObjectPrefab;
    List<Vector3> positions = new List<Vector3>{new Vector3(-6.25f,0,0), new Vector3(-1f,0,0), new Vector3(4f,0,0), new Vector3(9,0,0)};
    private void Start()
    {
        PhotonNetwork.Instantiate(gameObjectPrefab.name, positions[PhotonNetwork.CurrentRoom.PlayerCount-1], Quaternion.identity);
    }
    
}
