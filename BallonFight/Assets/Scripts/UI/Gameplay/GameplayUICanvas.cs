using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUICanvas : MonoBehaviour
{ 
    private GameplayCanvases gameplayCanvases;
    public void FirstInitialize(GameplayCanvases _canvases)
    {
        gameplayCanvases = _canvases;
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
