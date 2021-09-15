using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] PlayerSettingsScriptableObjects playerSettings;
    Vector3 spawnPoint;
    bool stuned;
    public int playerNumber;
    public Rigidbody2D body;
    Joystick joystick;
    PhotonView view;
    // Start is called before the first frame update
    void Awake()
    {
        view = GetComponent<PhotonView>();
        body = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        spawnPoint = transform.position;
        playerNumber = GameObject.FindGameObjectsWithTag("Player").Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(view.IsMine && !stuned)
        {
            Move(Input.GetAxisRaw("Horizontal")*playerSettings.playerAcceleration*Time.fixedDeltaTime,
                 Input.GetAxisRaw("Vertical")*playerSettings.playerAcceleration*Time.fixedDeltaTime);        
            
            Move(joystick.Horizontal*playerSettings.playerAcceleration*Time.fixedDeltaTime,
                 joystick.Vertical*playerSettings.playerAcceleration*Time.fixedDeltaTime);        
        }
    }
    void Move(float horizontal, float vertical)
    {
        Vector2 move = new Vector2();
        move.Set(horizontal,vertical);
        body.AddForce(move,ForceMode2D.Force);
    }
    public void ResetPosition()
    {
        transform.position = spawnPoint;
        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
    }
    public IEnumerator Stun(PlayerMove player)
    {
        stuned = true;
        Vector2 knockbackDirection = (body.velocity*-1) + player.body.velocity*Time.fixedDeltaTime;
        body.AddForce(knockbackDirection, ForceMode2D.Impulse);
        yield return new WaitForSeconds(3);
        stuned = false;
    }
    public void GetKnockback(PlayerMove player)
    {
        Vector2 knockbackDirection = (body.velocity + player.body.velocity*Time.fixedDeltaTime)*-1;
        body.AddForce(knockbackDirection,ForceMode2D.Impulse);
    }
}
