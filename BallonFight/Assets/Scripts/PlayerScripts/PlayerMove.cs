using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] PlayerSettingsScriptableObjects playerSettings;
    Vector3 spawnPoint;
    bool stuned;
    public int playerNumber;
    public Rigidbody2D body;
    Joystick joystick;
    string horizontalAxis;
    string verticalAxis;
    // Start is called before the first frame update
    void Awake()
    {
        horizontalAxis = string.Concat("Horizontal",playerNumber);
        verticalAxis = string.Concat("Vertical",playerNumber);
        body = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        spawnPoint = transform.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!stuned)
        {
            Move(Input.GetAxisRaw(horizontalAxis)*playerSettings.playerAcceleration*Time.fixedDeltaTime,
                 Input.GetAxisRaw(verticalAxis)*playerSettings.playerAcceleration*Time.fixedDeltaTime);        
            if(playerNumber == 1)
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
