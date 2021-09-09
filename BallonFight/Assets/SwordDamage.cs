using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{ 
    [SerializeField]PlayerMove player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerKill>().Damage();
            player.ResetPosition();
        }
        Debug.Log(other.tag);
        
    }
}
