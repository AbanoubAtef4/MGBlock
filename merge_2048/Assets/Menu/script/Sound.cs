using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    GameObject[] s;

    private void Awake()
    {   

        s = GameObject.FindGameObjectsWithTag("sound");
        if (s.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);

    }

}