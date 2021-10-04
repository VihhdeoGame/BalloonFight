using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OthersLifeDisplay : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    private void OnEnable()
    {
        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount-1; i++)
        {
            Instantiate(prefab,transform);           
        }       
    }
}
