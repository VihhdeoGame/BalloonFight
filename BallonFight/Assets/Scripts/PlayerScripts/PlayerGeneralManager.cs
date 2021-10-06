﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerGeneralManager : MonoBehaviour
{
    Vector3 spawnPoint;
    bool stuned;
    public int playerNumber;
    public Rigidbody2D body;
    public Color color;
    Animator animator; 
    Joystick joystick;
    PhotonView view;
    PlayerLifeDisplay display;
    OthersLifeDisplay othersDisplay;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator stringAnimator;
    public int currentLives;
    public bool isReady = false;
    // Start is called before the first frame update
    void Awake()
    {
        display = FindObjectOfType<PlayerLifeDisplay>();
        currentLives = GameManager.PlayerManager.playerMaxLives;
        animator = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
        body = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        spawnPoint = transform.position;
        playerNumber = view.ControllerActorNr;
        color = GameManager.PlayerManager.SetColor(playerNumber);
        sprite.color = color;
        view.RPC("RPC_SetReady", RpcTarget.AllBuffered);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(display == null)
        {
            display = FindObjectOfType<PlayerLifeDisplay>();
        }
        if(othersDisplay == null)
        {
            othersDisplay = FindObjectOfType<OthersLifeDisplay>();
        }
        if(joystick == null)
        {
            joystick = FindObjectOfType<Joystick>();
        }
        else
            if(view.IsMine && !stuned)
            {
                Move(Input.GetAxisRaw("Horizontal")*GameManager.PlayerManager.playerAcceleration*Time.fixedDeltaTime,
                    Input.GetAxisRaw("Vertical")*GameManager.PlayerManager.playerAcceleration*Time.fixedDeltaTime);        
                
                Move(joystick.Horizontal*GameManager.PlayerManager.playerAcceleration*Time.fixedDeltaTime,
                    joystick.Vertical*GameManager.PlayerManager.playerAcceleration*Time.fixedDeltaTime);       
            }
    }
    void Move(float horizontal, float vertical)
    {
        Vector2 move = new Vector2();
        move.Set(horizontal,vertical);
        body.AddForce(move,ForceMode2D.Force);
        if(Mathf.Abs(horizontal/GameManager.PlayerManager.playerAcceleration/Time.fixedDeltaTime) > 0 
        || Mathf.Abs(vertical/GameManager.PlayerManager.playerAcceleration/Time.fixedDeltaTime) > 0)
        {
        animator.SetFloat("Horizontal", horizontal/GameManager.PlayerManager.playerAcceleration/Time.fixedDeltaTime);
        animator.SetFloat("Vertical", vertical/GameManager.PlayerManager.playerAcceleration/Time.fixedDeltaTime); 
        }
    
    }
    public void ResetPosition()
    {
        transform.position = spawnPoint;
        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
        if(currentLives <= 0)
            Kill();
        else
        {
            animator.SetBool("Death", false);
            stringAnimator.enabled = true;
        }    
    }
    public IEnumerator Stun(PlayerGeneralManager player)
    {
        stuned = true;
        animator.SetBool("Stunned", true);
        Vector2 knockbackDirection = (body.velocity*-1) + player.body.velocity*Time.fixedDeltaTime;
        body.AddForce(knockbackDirection, ForceMode2D.Impulse);
        yield return new WaitForSeconds(3);
        animator.SetBool("Stunned", false);
        stuned = false;
    }
    public void GetKnockback(PlayerGeneralManager player)
    {
        Vector2 knockbackDirection = (body.velocity + player.body.velocity*Time.fixedDeltaTime)*-1;
        body.AddForce(knockbackDirection,ForceMode2D.Impulse);
    }
    public void Damage()
    {
        view.RPC("RPC_SendDammage", RpcTarget.All);
    }
    void Kill()
    {
        gameObject.SetActive(false);
    }

    [PunRPC]
    private void RPC_SendDammage()
    {
        currentLives--;
        if(view.IsMine)
            display.UpdateHearts(currentLives);
        else
            othersDisplay.othersLives[playerNumber].UpdateHearts(currentLives);
        animator.SetBool("Death", true);
        stringAnimator.enabled = false;
    }
    [PunRPC]
    private void RPC_SetReady()
    {
        isReady = true;
    }
}
