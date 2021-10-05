using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class OtherLifeDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField]GameObject lifePrefab;
    List<GameObject> lifeArray;
    int currentLives;
    public override void OnEnable() 
    {
        base.OnEnable();
        lifeArray = new List<GameObject>();
    }
    public void DisplayHearts(int maxLives)
    {
        for (int i = 0; i < maxLives; i++)
        {
            lifeArray.Add(Instantiate(lifePrefab,transform));
        }
        currentLives = maxLives;
    }
    public void UpdateHearts(int lives)
    {
        if(currentLives > lives)
        {
            lifeArray[currentLives-1].SetActive(false);
            currentLives = lives;
        }
    }
}
