using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] cloudsPrefabs;
    List<GameObject> clouds = new List<GameObject>();
    List<float> randomVelocity = new List<float>();
    bool isSpawning;
    void Start() 
    {
        int initialClouds = Random.Range(4,10);
        for (int i = 0; i < initialClouds; i++)
        {
            int prefabIndex = Random.Range(0,4);
            float randomX = Random.Range(-960,960); 
            float randomY = Random.Range(-540,540);
            Vector3 instancePosition = new Vector3(randomX,randomY,0);
            clouds.Add(Instantiate(cloudsPrefabs[prefabIndex],transform,false));
            float localScale = Random.Range(0.1f,0.3f);
            clouds[clouds.Count-1].transform.localScale = new Vector3(localScale,localScale,1);
            clouds[clouds.Count-1].transform.localPosition = instancePosition;
            randomVelocity.Add(Random.Range(-80,-30));
        }
        
    }

    void Update() 
    {
        for (int i = 0; i < clouds.Count; i++)
        {
            clouds[i].transform.Translate(randomVelocity[i]*Time.deltaTime,0,0,Space.Self);
            if(clouds[i].transform.localPosition.x < -1500)
            {
                Destroy(clouds[i]);
                clouds.RemoveAt(i);
                randomVelocity.RemoveAt(i);
            }
        }
        if(!isSpawning)
            StartCoroutine(SpawnNewClouds());
    }

    IEnumerator SpawnNewClouds()
    {
        isSpawning = true;
        int prefabIndex = Random.Range(0,4);
        float randomY = Random.Range(-540,540);
        float localScale = Random.Range(0.1f,0.3f);
        Vector3 instancePosition = new Vector3(1500,randomY,0);
        clouds.Add(Instantiate(cloudsPrefabs[prefabIndex],transform,false));
        clouds[clouds.Count-1].transform.localScale = new Vector3(localScale,localScale,1);
        clouds[clouds.Count-1].transform.localPosition = instancePosition;
        randomVelocity.Add(Random.Range(-80,-30));
        yield return new WaitForSeconds(Random.Range(3,15));
        isSpawning = false;
    }
}
