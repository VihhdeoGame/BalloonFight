using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//Class used to create a sprite to display the player number
public class PlayerTextDisplay : MonoBehaviour
{
    [SerializeField]PlayerGeneralManager parent;
    TextMesh textBox;
    void Awake() 
    {
        textBox = GetComponent<TextMesh>();
        textBox.text = PhotonNetwork.CurrentRoom.Players[parent.playerNumber].NickName.ToString().Substring(0,3);
    }
    
}
