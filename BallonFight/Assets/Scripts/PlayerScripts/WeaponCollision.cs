using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{ 
    public PlayerGeneralManager player;
    bool colliding = false;
    private void Start()
    {
        player = GetComponentInParent<PlayerGeneralManager>();        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(tag.Equals("Sword"))
        {
            if(other.CompareTag("Player") && !colliding)
            {
                colliding = true;
                other.GetComponent<PlayerGeneralManager>().Damage();
                player.ResetPosition();
                colliding = false;
            }
            if(other.CompareTag("Shield") && !colliding)
            {
                colliding = true;
                StartCoroutine(player.Stun(other.GetComponent<WeaponCollision>().player));
                colliding = false;            
            }
            if(other.CompareTag("Sword") && !colliding)
            {
                colliding = true;
                player.GetKnockback(other.GetComponent<WeaponCollision>().player);
                colliding = false;            
            }
        }
        if(tag.Equals("Shield"))
        {
            if(other.CompareTag("Sword") && !colliding)
            {
                colliding = true;
                player.GetKnockback(other.GetComponent<WeaponCollision>().player);
                colliding = false;            
            }
            if(other.CompareTag("Shield") && !colliding)
            {
                colliding = true;
                player.GetKnockback(other.GetComponent<WeaponCollision>().player);
                colliding = false;            
            }
            if(other.CompareTag("Player") && !colliding)
            {
                colliding = true;
                player.GetKnockback(other.GetComponent<PlayerGeneralManager>());
                colliding = false;            
            }
        }        
    }
}
