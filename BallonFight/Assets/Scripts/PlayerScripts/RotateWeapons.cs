using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RotateWeapons : MonoBehaviour
{
    PhotonView view;
    RotateButtons buttons;
    [SerializeField]Transform sword;
    [SerializeField]Transform shield;
    [SerializeField]PlayerGeneralManager parent;
    private void Awake() 
    {
        view = GetComponentInParent<PhotonView>();
        buttons = FindObjectOfType<RotateButtons>();
        SetInitialPosition();        
    }
    private void LateUpdate()
    {
#if UNITY_ANDROID
        if(buttons == null)
        {
            buttons = FindObjectOfType<RotateButtons>();
        }
        else
            if(view.IsMine && !parent.stuned)
            {
                if(buttons.isRotatingLeft()) { Rotate(false);}
                if(buttons.isRotatingRight()){ Rotate(true);}
            }
#elif UNITY_STANDALONE || UNITY_EDITOR
        if(Input.GetKey(KeyCode.E)){ Rotate(true);}        
        if(Input.GetKey(KeyCode.Q)){ Rotate(false);}
#endif
    }

    void SetInitialPosition()
    {
        float swordX = Mathf.Sin(GameManager.PlayerManager.weaponInitialRotation*Mathf.Deg2Rad)*GameManager.PlayerManager.weaponDistance;
        float swordY = Mathf.Cos(GameManager.PlayerManager.weaponInitialRotation*Mathf.Deg2Rad)*GameManager.PlayerManager.weaponDistance; 
        sword.transform.localPosition = new Vector3(swordX,swordY,0);
        
        float shieldX = -Mathf.Sin(GameManager.PlayerManager.weaponInitialRotation*Mathf.Deg2Rad)*GameManager.PlayerManager.weaponDistance;
        float shieldY = -Mathf.Cos(GameManager.PlayerManager.weaponInitialRotation*Mathf.Deg2Rad)*GameManager.PlayerManager.weaponDistance; 
        shield.transform.localPosition = new Vector3(shieldX,shieldY,0);
    }
    void Rotate(bool isRight)
    {
        Vector3 rotation = new Vector3();
        if(isRight){ rotation = new Vector3(0,0,-GameManager.PlayerManager.rotationSpeed*Time.deltaTime); }
        if(!isRight){ rotation = new Vector3(0,0,GameManager.PlayerManager.rotationSpeed*Time.deltaTime); }
        transform.Rotate(rotation);
    }
}
