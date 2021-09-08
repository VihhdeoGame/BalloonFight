using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    MusicController musicController;
    Vector3 spawnPoint;
    GameObject deathScreen;
    Rigidbody2D body;
    int lives = 3;
    // Update is called once per frame
    void Awake() 
    {
        body = GetComponent<Rigidbody2D>();
        deathScreen = GameObject.FindGameObjectWithTag("DeathScreen");
        musicController = FindObjectOfType<MusicController>();
        spawnPoint = transform.position;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            lives--;
            if(lives <= 0)
                Kill();
            else
            {
                transform.position = spawnPoint;
                body.velocity = Vector2.zero;
                body.angularVelocity = 0;
            }
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
