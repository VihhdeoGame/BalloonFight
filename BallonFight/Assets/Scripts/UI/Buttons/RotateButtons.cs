using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButtons : MonoBehaviour
{
    bool rotateRight;
    bool rotateLeft;
    public void SetRotateRight(bool rotate)
    {
        rotateRight = rotate;
    }
    
    public void SetRotateLeft(bool rotate)
    {
        rotateLeft = rotate;
    }
    
    public bool isRotatingLeft()
    {
        return rotateLeft;
    }
    public bool isRotatingRight()
    {
        return rotateRight;
    }
}
