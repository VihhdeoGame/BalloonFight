using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 spawnPoint;
    public int playerNumber;
    public Rigidbody2D body;
    [SerializeField][Range(75,300)]float force;
    Joystick joystick;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(Input.GetAxisRaw("Horizontal"+playerNumber)*force*Time.fixedDeltaTime,Input.GetAxisRaw("Vertical"+playerNumber)*force*Time.fixedDeltaTime);        
        if(playerNumber == 1)
            Move(joystick.Horizontal*force*Time.fixedDeltaTime,joystick.Vertical*force*Time.fixedDeltaTime);        
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
}
