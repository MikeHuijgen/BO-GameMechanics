using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooping : MonoBehaviour
{

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag ("AudioLoop"); 
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
