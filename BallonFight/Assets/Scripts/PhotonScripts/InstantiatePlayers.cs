﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class InstantiatePlayers : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private void Awake() 
    {
        GameManager.NetworkInstantiante(prefab, transform.position, Quaternion.identity);        
    }
}
