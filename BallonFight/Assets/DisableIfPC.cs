using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfPC : MonoBehaviour
{
    private void OnEnable()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
    gameObject.SetActive(false);
#endif
    }
}
