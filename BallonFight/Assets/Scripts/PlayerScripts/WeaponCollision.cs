using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{ 
    public PlayerGeneralManager player;
    private void Start()
    {
        player = GetComponentInParent<PlayerGeneralManager>();        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(tag.Equals("Sword"))
        {
            if(other.CompareTag("Player"))
            {
                other.GetComponent<PlayerGeneralManager>().Damage();
                player.ResetPosition();
            }
            if(other.CompareTag("Shield"))
            {
                StartCoroutine(player.Stun(other.GetComponent<WeaponCollision>().player));
            }
            if(other.CompareTag("Sword"))
            {
                player.GetKnockback(other.GetComponent<WeaponCollision>().player);
            }
        }
        if(tag.Equals("Shield"))
        {
            if(other.CompareTag("Sword"))
            {
                player.GetKnockback(other.GetComponent<WeaponCollision>().player);
            }
            if(other.CompareTag("Shield"))
            {
                player.GetKnockback(other.GetComponent<WeaponCollision>().player);
            }
            if(other.CompareTag("Player"))
            {
                player.GetKnockback(other.GetComponent<PlayerGeneralManager>());
            }
        }        
    }
}
