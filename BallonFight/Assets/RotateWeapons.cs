using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class RotateWeapons : MonoBehaviour
{
    [SerializeField]Transform sword;
    [SerializeField]Transform shield;
    private void Awake() 
    {
        SetInitialPosition();        
    }

    private void LateUpdate()
    {
        if(Input.GetKey(KeyCode.E)){ Rotate(true);}        
        if(Input.GetKey(KeyCode.Q)){ Rotate(false);}        
    }

    void SetInitialPosition()
    {
        float swordX = Mathf.Sin(GameManager.Instance.playerManager.weaponInitialRotation*Mathf.Deg2Rad)*GameManager.Instance.playerManager.weaponDistance;
        float swordY = Mathf.Cos(GameManager.Instance.playerManager.weaponInitialRotation*Mathf.Deg2Rad)*GameManager.Instance.playerManager.weaponDistance; 
        sword.transform.localPosition = new Vector3(swordX,swordY,0);
        
        float shieldX = -Mathf.Sin(GameManager.Instance.playerManager.weaponInitialRotation*Mathf.Deg2Rad)*GameManager.Instance.playerManager.weaponDistance;
        float shieldY = -Mathf.Cos(GameManager.Instance.playerManager.weaponInitialRotation*Mathf.Deg2Rad)*GameManager.Instance.playerManager.weaponDistance; 
        shield.transform.localPosition = new Vector3(shieldX,shieldY,0);
    }
    void Rotate(bool isRight)
    {
        Vector3 rotation = new Vector3();
        if(isRight){ rotation = new Vector3(0,0,-GameManager.Instance.playerManager.rotationSpeed*Time.deltaTime); }
        if(!isRight){ rotation = new Vector3(0,0,GameManager.Instance.playerManager.rotationSpeed*Time.deltaTime); }
        transform.Rotate(rotation);
    }
}
