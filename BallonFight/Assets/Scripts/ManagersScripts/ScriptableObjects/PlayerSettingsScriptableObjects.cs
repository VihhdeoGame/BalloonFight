using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettingsData", menuName = "ScriptableObjects/PlayerSettingsData", order = 1)]
public class PlayerSettingsScriptableObjects : ScriptableObject
{
    [Header("Player Movement")]
    [Range(0,500)]public float playerAcceleration;
    [Range(0,500)]public float rotationSpeed;
    [Range(0,360)]public float weaponInitialRotation;
    [Range(0,500)]public float weaponDistance;
    
    [Header("Lives")]
    [Range(1,5)]public int playerMaxLives;

    [Header("Player Colors")]
    public Color[] playerColors;

    public Color SetColor(int playerNumber)
    {
        return playerColors[playerNumber - 1];
    }
}
