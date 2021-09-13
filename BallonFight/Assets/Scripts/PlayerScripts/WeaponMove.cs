using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour
{
    [SerializeField] PlayerSettingsScriptableObjects playerSettings;
    
    int direction = 0;
    float rAngle = 0;
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
        ChangeDirection(direction);
        Rotate();
    }
    void Rotate()
    {
        float swordX = Mathf.Sin(rAngle*Mathf.Deg2Rad)*playerSettings.weaponDistance;
        float swordY = Mathf.Cos(rAngle*Mathf.Deg2Rad)*playerSettings.weaponDistance; 
        sword.transform.localPosition = new Vector3(swordX,swordY,0);
        
        float shieldX = -Mathf.Sin((rAngle)*Mathf.Deg2Rad)*playerSettings.weaponDistance;
        float shieldY = -Mathf.Cos((rAngle)*Mathf.Deg2Rad)*playerSettings.weaponDistance; 
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
            rAngle += playerSettings.rotationSpeed*Time.deltaTime ;
        }
        if(direction == 2)
        {
            rAngle -= playerSettings.rotationSpeed*Time.deltaTime ;
        }
        if(direction == 0)
        {

        }
    }
}
