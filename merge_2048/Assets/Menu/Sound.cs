using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    GameObject[] s;

    private void Awake()
    {   
        // make sure there will always be 1 and only 1 sound manger game object in the game
        s = GameObject.FindGameObjectsWithTag("sound");
        if (s.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);

    }

}