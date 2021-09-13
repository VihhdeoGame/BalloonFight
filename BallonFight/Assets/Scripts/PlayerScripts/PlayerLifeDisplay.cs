using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeDisplay : MonoBehaviour
{
    [SerializeField]GameObject life;
    List<GameObject> lifeArray;
    [SerializeField]PlayerKill player;
    RectTransform rectTransform;
    int currentLives;
    private void Start() 
    {
        lifeArray = new List<GameObject>();
        rectTransform = GetComponent<RectTransform>();
        DisplayHearts(player.lives);
    }
    void DisplayHearts(int maxLives)
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x,100*maxLives);
        for (int i = 0; i < maxLives; i++)
        {
            lifeArray.Add(Instantiate(life,transform));
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
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x,100*lives);
    }
}
