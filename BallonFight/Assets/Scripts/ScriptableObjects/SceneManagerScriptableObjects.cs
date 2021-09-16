using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneManagerData", menuName = "ScriptableObjects/SceneManagerData")]
public class SceneManagerScriptableObjects : ScriptableObject
{
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }    


}
