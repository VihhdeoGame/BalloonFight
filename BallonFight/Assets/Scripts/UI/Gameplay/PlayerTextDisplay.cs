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
        if(parent.playerNickName.Length > 3)
            textBox.text = parent.playerNickName.Substring(0,3);
        else
            textBox.text = parent.playerNickName;
    }
    
}
