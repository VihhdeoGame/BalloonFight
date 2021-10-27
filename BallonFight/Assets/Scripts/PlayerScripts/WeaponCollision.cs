using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class WeaponCollision : MonoBehaviourPun
{ 
    public PlayerGeneralManager player;
    private PhotonView view;
    private void Start()
    {
        player = GetComponentInParent<PlayerGeneralManager>();
        view = GetComponentInParent<PhotonView>();        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(view.IsMine)
        {
            if(tag.Equals("Sword"))
            {
                if(other.CompareTag("Sword"))
                {
                    player.GetKnockback(other.GetComponent<WeaponCollision>().player);          
                }
                if(other.CompareTag("Shield"))
                {
                    StartCoroutine(player.Stun(other.GetComponent<WeaponCollision>().player));           
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
            if(tag.Equals("Player"))
                if(other.CompareTag("Shield"))
                {
                    player.GetKnockback(other.GetComponent<WeaponCollision>().player);            
                }
        }
        else
        {
            if(tag.Equals("Sword") && !player.isDead)
                if(other.CompareTag("Player"))
                {
                    PlayerGeneralManager _other = other.GetComponent<PlayerGeneralManager>();
                    if(!_other.isDead)
                        _other.Damage();
                }
        }
    }
}
