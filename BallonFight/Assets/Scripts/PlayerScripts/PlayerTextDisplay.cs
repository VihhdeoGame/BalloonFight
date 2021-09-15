using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTextDisplay : MonoBehaviour
{
    [SerializeField]PlayerMove parent;
    [SerializeField]TMP_Text textBox;

    void Awake() 
    {
        textBox.text = string.Concat("P",parent.playerNumber);        
    }
    
}
