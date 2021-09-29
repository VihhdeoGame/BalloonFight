using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Basic Class to prevent objects from being destroyed between scenes
    [SerializeField]string nameTag;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(nameTag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
