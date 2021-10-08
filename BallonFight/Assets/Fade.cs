using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Image image;
    private void Awake() 
    {
        
        image = GetComponent<Image>();
        FadeOut();
    }
    public void FadeOut()
    {
        image.CrossFadeAlpha(0,0.5f,true);       
    }
    public void FadeIn()
    {
        image.CrossFadeAlpha(1,0.5f,true);
    }
    IEnumerator WaitforSceneChange(string _scene)
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.SceneManager.LoadScene(_scene);
    }
    IEnumerator WaitforSceneChange(int _scene)
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.SceneManager.LoadScene(_scene);
    }
    public void FadeInAndLoadScene(string _scene)
    {
        FadeIn();
        StartCoroutine(WaitforSceneChange(_scene));
    }
    public void FadeInAndLoadScene(int _scene)
    {
        FadeIn();
        StartCoroutine(WaitforSceneChange(_scene));
    }
}
