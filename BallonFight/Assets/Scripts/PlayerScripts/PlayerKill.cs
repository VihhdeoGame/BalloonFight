using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    MusicController musicController;
    GameObject deathScreen;
    PlayerMove player;
    [SerializeField]PlayerLifeDisplay display;
    [SerializeField] PlayerSettingsScriptableObjects playerSettings;
    public int currentLives;
    // Update is called once per frame
    void Awake() 
    {
        currentLives = playerSettings.playerMaxLives;
        player = GetComponent<PlayerMove>();
        deathScreen = GameObject.FindGameObjectWithTag("DeathScreen");
        musicController = FindObjectOfType<MusicController>();
    }
    public void Damage()
    {
        currentLives--;
        display.UpdateHearts(currentLives);
        if(currentLives <= 0)
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
