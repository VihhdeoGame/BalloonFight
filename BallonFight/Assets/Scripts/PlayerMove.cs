using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField][Range(75,300)]float force;
    Joystick joystick;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(Input.GetAxisRaw("Horizontal")*force*Time.fixedDeltaTime,Input.GetAxisRaw("Vertical")*force*Time.fixedDeltaTime);        
        Move(joystick.Horizontal*force*Time.fixedDeltaTime,joystick.Vertical*force*Time.fixedDeltaTime);        
    }
    void Move(float horizontal, float vertical)
    {
        Vector2 move = new Vector2();
        move.Set(horizontal,vertical);
        body.AddForce(move,ForceMode2D.Force);
    }
}
