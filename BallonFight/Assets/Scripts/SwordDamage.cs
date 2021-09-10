using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{ 
    public PlayerMove player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerKill>().Damage();
            player.ResetPosition();
        }
        if(other.CompareTag("Shield"))
        {
            StartCoroutine(player.Stun(other.GetComponent<ShieldDefense>().player));
        }
        if(other.CompareTag("Sword"))
        {
            player.GetKnockback(other.GetComponent<SwordDamage>().player);
        }        
    }
}
