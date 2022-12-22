using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class highscore : MonoBehaviour
{
    public TMP_Text text;
    public int high = 0;
    // Start is called before the first frame update

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        high = PlayerPrefs.GetInt("highsc");

        text.text = "High Score : " + high.ToString();
        Debug.Log("HIGH : " + high);
    }
}
