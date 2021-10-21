using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class used to create a sprite to display the player number
public class PlayerTextDisplay : MonoBehaviour
{
    [SerializeField]PlayerGeneralManager parent;
    TextMesh textBox;
    void Awake() 
    {
        textBox = GetComponent<TextMesh>();
        textBox.text = string.Concat("P",parent.playerNumber);
    }
    
}
