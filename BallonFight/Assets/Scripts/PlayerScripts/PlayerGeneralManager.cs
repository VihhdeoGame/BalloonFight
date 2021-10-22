using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerGeneralManager : MonoBehaviour,IOnEventCallback
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator stringAnimator;
    [SerializeField]Transform weapons;
    public Rigidbody2D body;
    public Color color;    
    public int playerNumber;
    public int currentLives;
    public bool isReady = false;
    public bool stuned;
    public bool respawnCooldown = false;
    AudioSource sfx;
    Vector3 spawnPoint;
    Animator animator; 
    Joystick joystick;
    PhotonView view;
    PlayerLifeDisplay display;
    OthersLifeDisplay othersDisplay;
    ScoreManager scoreManager;
    SpriteRenderer[] sprites;
    Collider2D[] colliders;
    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    void Awake()
    {
        colliders = GetComponentsInChildren<Collider2D>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
        sfx = GetComponent<AudioSource>(); 
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
        scoreManager = FindObjectOfType<ScoreManager>();
        view.RPC("RPC_SetReady", RpcTarget.AllBuffered, true);
    }
    void FixedUpdate()
    {
        if(scoreManager == null)
        {
            scoreManager = FindObjectOfType<ScoreManager>();
        }
        if(display == null)
        {
            display = FindObjectOfType<PlayerLifeDisplay>();
        }
        if(othersDisplay == null)
        {
            othersDisplay = FindObjectOfType<OthersLifeDisplay>();
        }
#if UNITY_ANDROID
        if(joystick == null)
        {
            joystick = FindObjectOfType<Joystick>();
        }
        else
            if(view.IsMine && !stuned)
            {   
                Move(joystick.Horizontal*GameManager.PlayerManager.playerAcceleration*Time.fixedDeltaTime,
                     joystick.Vertical*GameManager.PlayerManager.playerAcceleration*Time.fixedDeltaTime);       
            }
#elif UNITY_STANDALONE || UNITY_EDITOR
        if(view.IsMine && !stuned)
            {
                Move(Input.GetAxisRaw("Horizontal")*GameManager.PlayerManager.playerAcceleration*Time.fixedDeltaTime,
                     Input.GetAxisRaw("Vertical")*GameManager.PlayerManager.playerAcceleration*Time.fixedDeltaTime);
            }
#endif
        if(scoreManager.ScoresReceived.Count == PhotonNetwork.CurrentRoom.PlayerCount - 1 && isReady && display != null)
            {
                GetVictoryScreen();
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
        weapons.rotation = Quaternion.identity;
        if(currentLives <= 0 && view.IsMine)
            Kill();
        else
        {
            animator.SetBool("Death", false);
            stringAnimator.enabled = true;
            stuned = false;
            if(view.IsMine)
                animator.SetBool("Stunned", false);
            StartCoroutine(RespawnCooldown());
        }    
    }
    public IEnumerator Stun(PlayerGeneralManager player)
    {
        stuned = true;
        if(view.IsMine)
            animator.SetBool("Stunned", true);
        GetKnockback(player);
        yield return new WaitForSeconds(3);
        if(view.IsMine)
            animator.SetBool("Stunned", false);
        stuned = false;
    }
    public IEnumerator RespawnCooldown()
    {
        respawnCooldown = true;
        yield return new WaitForSeconds(3);
        respawnCooldown = false;
    }
    public void GetKnockback(PlayerGeneralManager player)
    {
        Vector2 knockbackDirection = (body.velocity*-1) + player.body.velocity*Time.fixedDeltaTime;
        body.AddForce(knockbackDirection,ForceMode2D.Impulse);
    }
    public void Damage()
    {
        if(view.IsMine && !respawnCooldown)
            view.RPC("RPC_SendDammage", RpcTarget.All);
    }
    void Kill()
    {
        object[] datas = new object[] {playerNumber};
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.MasterClient };
        PhotonNetwork.RaiseEvent(Const.SEND_SCORE_EVENT,datas, raiseEventOptions, SendOptions.SendReliable);
        Debug.Log("sending from kill");
        view.RPC("RPC_SetReady", RpcTarget.All,false);
        SetRender(false);
    }
    void GetVictoryScreen()
    {
        object[] datas = new object[] {playerNumber};
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.MasterClient };
        PhotonNetwork.RaiseEvent(Const.SEND_SCORE_EVENT,datas, raiseEventOptions, SendOptions.SendReliable);
        Debug.Log("sending from victory");
        view.RPC("RPC_SetReady", RpcTarget.All,false);
        SetRender(false);
    }
    public void ResetValues()
    {
        SetRender(true);
        view.RPC("RPC_SetReady", RpcTarget.All,true);
        transform.position = spawnPoint;
        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
        currentLives = GameManager.PlayerManager.playerMaxLives;
        if(view.IsMine)
        animator.SetBool("Death", false);
        UpdateHearts();
    }    
    private void UpdateHearts()
    {
        if(view.IsMine)
            display.UpdateHearts(currentLives);
        else
            othersDisplay.othersLives[playerNumber].UpdateHearts(currentLives);
    }

    public void PlaySFX()
    {
        sfx.Play();
    }
    void SetRender(bool active)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].enabled = active;            
        }
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = active;            
        }
    }
    [PunRPC]
    private void RPC_SendDammage()
    {
        currentLives--;
        UpdateHearts();
        if(view.IsMine)
        {
            animator.SetBool("Stunned", false);
            animator.SetBool("Death", true);
        }
        stringAnimator.enabled = false;
    }
    [PunRPC]
    private void RPC_SetReady(bool _isReady)
    {
        isReady = _isReady;
    }
    public void OnEvent(EventData photonEvent)
    {
        if(photonEvent.Code == Const.PLAY_AGAIN_EVENT)
        {
            ResetValues();
        }
    }
}
