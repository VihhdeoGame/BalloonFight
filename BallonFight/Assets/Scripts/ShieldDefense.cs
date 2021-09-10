using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDefense : MonoBehaviour
{
    public PlayerMove player;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Sword"))
        {
            player.GetKnockback(other.GetComponent<SwordDamage>().player);
        }
        if(other.CompareTag("Shield"))
        {
            player.GetKnockback(other.GetComponent<ShieldDefense>().player);
        }
        if(other.CompareTag("Player"))
        {
            player.GetKnockback(other.GetComponent<PlayerMove>());
        }       
    }
}
