using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayCanvases : MonoBehaviour
{
    [SerializeField]
    private GameplayLoadingBackgroundCanvas backgroundCanvas;
    public GameplayLoadingBackgroundCanvas BackgroundCanvas{get {return backgroundCanvas; } }
    [SerializeField]
    private GameplayUICanvas gameplayUICanvas;
    public GameplayUICanvas GameplayUICanvas {get {return gameplayUICanvas; }}
    private void Awake()
    {
       FirstInitialize();
    }
    private void FirstInitialize()
    {
       gameplayUICanvas.FirstInitialize(this);
       backgroundCanvas.FirstInitialize(this);
    }
}
