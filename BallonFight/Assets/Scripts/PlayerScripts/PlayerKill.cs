using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    PlayerMove player;
    [SerializeField]PlayerLifeDisplay display;
    public int currentLives;
    void Awake() 
    {
        currentLives = GameManager.PlayerManager.playerMaxLives;
        player = GetComponent<PlayerMove>();
    }
    public void Damage()
    {
        currentLives--;
        if(currentLives <= 0)
            Kill();
        else
        {
            player.ResetPosition();
        }
    }
    void Kill()
    {
        gameObject.SetActive(false);
    }

}
