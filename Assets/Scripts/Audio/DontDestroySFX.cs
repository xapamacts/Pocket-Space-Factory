using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySFX : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] sfxObj = GameObject.FindGameObjectsWithTag("SFX");

        if(sfxObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }
}

