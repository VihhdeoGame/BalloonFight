using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour
{
    public float distance;
    float rAngle = 0;
    [SerializeField]Transform sword;
    [SerializeField]Transform shield;
    [SerializeField]Transform player;

    // Update is called once per frame
    void Start() 
    {
        Rotate();
        
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
            Rotate(false);
        if(Input.GetKey(KeyCode.E))
            Rotate(true);
    }
    void Rotate()
    {
        float swordX = Mathf.Sin(rAngle*Mathf.Deg2Rad)*distance;
        float swordY = Mathf.Cos(rAngle*Mathf.Deg2Rad)*distance; 
        sword.transform.localPosition = new Vector3(swordX,swordY,0);
        
        float shieldX = -Mathf.Sin((rAngle)*Mathf.Deg2Rad)*distance;
        float shieldY = -Mathf.Cos((rAngle)*Mathf.Deg2Rad)*distance; 
        shield.transform.localPosition = new Vector3(shieldX,shieldY,0);
        
        Vector3 swordVector = sword.transform.position - player.transform.position;
        float swordA = Mathf.Atan2(swordVector.x, swordVector.y) * Mathf.Rad2Deg;
        sword.transform.rotation = Quaternion.Euler(0,0,-swordA);
        
        Vector3 shieldVector = shield.transform.position - player.transform.position;
        float shieldA = Mathf.Atan2(swordVector.x, swordVector.y) * Mathf.Rad2Deg;
        shield.transform.rotation = Quaternion.Euler(0,0,-shieldA);
        
    }
    void Rotate(bool dirRight)
    {
        if(!dirRight)
        {
            rAngle--;
        }
        if(dirRight)
        {
            rAngle++;
        }
        float swordX = Mathf.Sin(rAngle*Mathf.Deg2Rad)*distance;
        float swordY = Mathf.Cos(rAngle*Mathf.Deg2Rad)*distance; 
        sword.transform.localPosition = new Vector3(swordX,swordY,0);

        float shieldX = -Mathf.Sin((rAngle)*Mathf.Deg2Rad)*distance;
        float shieldY = -Mathf.Cos((rAngle)*Mathf.Deg2Rad)*distance; 
        shield.transform.localPosition = new Vector3(shieldX,shieldY,0);

        Vector3 swordVector = sword.transform.position - player.transform.position;
        float swordA = Mathf.Atan2(swordVector.x, swordVector.y) * Mathf.Rad2Deg;
        sword.transform.rotation = Quaternion.Euler(0,0,-swordA);
        
        Vector3 shieldVector = shield.transform.position - player.transform.position;
        float shieldA = Mathf.Atan2(swordVector.x, swordVector.y) * Mathf.Rad2Deg;
        shield.transform.rotation = Quaternion.Euler(0,0,-shieldA);
    }
}
