using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class highscore : MonoBehaviour
{
    public TMP_Text text;
    public float high;
    // Start is called before the first frame update

    void Start()
    {
        high = PlayerPrefs.GetFloat("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "High Score : " + high;

    }
}
