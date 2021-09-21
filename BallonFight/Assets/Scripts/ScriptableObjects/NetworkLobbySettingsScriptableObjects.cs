using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

[CreateAssetMenu(fileName = "NetworkLobbySettingsData", menuName = "ScriptableObjects/NetworkLobbySettingsData")]
public class NetworkLobbySettingsScriptableObjects : ScriptableObject
{
    public string lobbyName;
    public LobbyType lobbyType;
}
