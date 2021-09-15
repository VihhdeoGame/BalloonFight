using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GetPlayerWeapons : MonoBehaviourPunCallbacks
{
    WeaponMove weapons;
    private void Update() 
    {
        if(weapons == null)
            weapons = GameObject.FindObjectOfType<WeaponMove>();
    }
    public void RotateLeft()
    {
        weapons.ChangeDirection(2);
    }
    public void StopRotation()
    {
        weapons.ChangeDirection(0);
    }
    public void RotateRight()
    {
        weapons.ChangeDirection(1);
    }
}
