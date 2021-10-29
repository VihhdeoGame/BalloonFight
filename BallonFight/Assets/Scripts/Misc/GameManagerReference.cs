using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerReference : MonoBehaviour
{
    //GameManager needs at least one reference in the first scene of the game to be called by other classes
    public GameManager gameManagerReference;
    private void OnEnable()
    {
        GameManager.GameSettings.GameVersion = Application.version;        
    }
}
