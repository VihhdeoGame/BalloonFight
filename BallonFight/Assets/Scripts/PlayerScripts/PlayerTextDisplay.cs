using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTextDisplay : MonoBehaviour
{
    [SerializeField]PlayerMove parent;
    [SerializeField]TextMesh textBox;

    void Awake() 
    {
        textBox.text = string.Concat("P",parent.playerNumber);
    }
    
}
