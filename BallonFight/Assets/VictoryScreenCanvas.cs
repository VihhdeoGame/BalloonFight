﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryScreenCanvas : MonoBehaviour
{
    private GameplayCanvases gameplayCanvases;
    [SerializeField]
    ScoreManager score;
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
