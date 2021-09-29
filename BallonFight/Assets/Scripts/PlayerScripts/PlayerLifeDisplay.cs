using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeDisplay : MonoBehaviour
{
    [SerializeField]GameObject lifePrefab;
    List<GameObject> lifeArray;
    [SerializeField]PlayerGeneralManager player;
    int currentLives;
    private void Start() 
    {
        lifeArray = new List<GameObject>();
        DisplayHearts(player.currentLives);
    }
    void DisplayHearts(int maxLives)
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
            Destroy(lifeArray[currentLives-1]);
            lifeArray.RemoveAt(currentLives-1);
            currentLives = lives;
        }
    }
}
