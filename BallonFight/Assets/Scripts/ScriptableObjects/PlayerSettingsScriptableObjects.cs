using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettingsData", menuName = "ScriptableObjects/PlayerSettingsData", order = 1)]
public class PlayerSettingsScriptableObjects : ScriptableObject
{
    [Range(0,500)]public float playerAcceleration;
    
    [Range(0,500)]public float rotationSpeed;

    [Range(0,500)]public float weaponDistance;

}
