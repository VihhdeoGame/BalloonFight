using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

//Class responsible for player instances though Photon
public class InstantiatePlayers : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private void Awake() 
    {
        GameManager.NetworkInstantiante(prefab, transform.position, Quaternion.identity);        
    }
}
