using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    MusicController musicController;
    GameObject deathScreen;
    PlayerMove player;
    [SerializeField]PlayerLifeDisplay display;
    public int lives = 3;
    // Update is called once per frame
    void Awake() 
    {
        player = GetComponent<PlayerMove>();
        deathScreen = GameObject.FindGameObjectWithTag("DeathScreen");
        musicController = FindObjectOfType<MusicController>();
    }
    public void Damage()
    {
        lives--;
        display.UpdateHearts(lives);
        if(lives <= 0)
            Kill();
        else
        {
            player.ResetPosition();
        }
    }
    void Kill()
    {
        musicController.volume = 0;
        musicController.ChangeVolume();
        deathScreen.SetActive(true);
        Destroy(this.gameObject);
    }

}
