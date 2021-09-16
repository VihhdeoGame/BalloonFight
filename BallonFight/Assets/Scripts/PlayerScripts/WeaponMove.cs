using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class WeaponMove : MonoBehaviourPunCallbacks
{
    int direction = 0;
    float rAngle = 0;
    [SerializeField]PhotonView view;
    [SerializeField]Transform sword;
    [SerializeField]Transform shield;
    [SerializeField]Transform player;

    // Update is called once per frame
    void Start() 
    {
        Rotate();
    }
    void LateUpdate()
    {
        Rotate();
        /*if(view.IsMine)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                ChangeDirection(2);
            }
            if(Input.GetKey(KeyCode.E))
            {
                ChangeDirection(1);
            }
        }*/
    }
    void Rotate()
    {
        float swordX = Mathf.Sin(rAngle*Mathf.Deg2Rad)*GameManager.Instance.playerManager.weaponDistance;
        float swordY = Mathf.Cos(rAngle*Mathf.Deg2Rad)*GameManager.Instance.playerManager.weaponDistance; 
        sword.transform.localPosition = new Vector3(swordX,swordY,0);
        
        float shieldX = -Mathf.Sin((rAngle)*Mathf.Deg2Rad)*GameManager.Instance.playerManager.weaponDistance;
        float shieldY = -Mathf.Cos((rAngle)*Mathf.Deg2Rad)*GameManager.Instance.playerManager.weaponDistance; 
        shield.transform.localPosition = new Vector3(shieldX,shieldY,0);
        
        Vector3 swordVector = player.transform.position - sword.transform.position;
        float swordA = -Mathf.Atan2(swordVector.x, swordVector.y) * Mathf.Rad2Deg;
        sword.transform.rotation = Quaternion.Euler(0,0,swordA);
        
        Vector3 shieldVector = player.transform.position - shield.transform.position;
        float shieldA = -Mathf.Atan2(swordVector.x, swordVector.y) * Mathf.Rad2Deg;
        shield.transform.rotation = Quaternion.Euler(0,0,shieldA);
    }
    public void ChangeDirection(int direction)
    {
        this.direction = direction;
        if(direction == 1)
        {
            rAngle += GameManager.Instance.playerManager.rotationSpeed*Time.deltaTime ;
        }
        if(direction == 2)
        {
            rAngle -= GameManager.Instance.playerManager.rotationSpeed*Time.deltaTime ;
        }
        if(direction == 0)
        {

        }
    }
}
