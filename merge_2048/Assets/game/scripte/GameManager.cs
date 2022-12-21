using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TMP_Text _score;
    public int _width = 6;
    public int _height = 8;
    public Transform[] cellposarray;
    public bool[] isfree;
    public Transform[,] _cellposlist;
    public GameObject blockprefab;
    public float Score=0;
    public float highscore = 0;
    public bool finish;
    ButtonScript sc;
    public GameObject win;
    public TMP_Text high;
    public AudioSource end;

    int z = 0;


    void Start()
    {

        GetPosCell(24);
        end = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _score.text ="Score : " + Score.ToString();
        if (finish)
        {
            end.Play();
            high.text = "Your Score : " + Score.ToString();
            win.SetActive(true);
        }
    }


    public void GetPosCell(int value)
    {
        
        

        var center = new Vector2((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f);
        Camera.main.transform.position = new Vector3(center.x, center.y, -10);


        
        for (int i = 0; i < value; i++)
        {
                float rand = Random.value;
                
                GameObject block = Instantiate(blockprefab, cellposarray[i]);
                block.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                if (rand <= 0.1f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "2";
                    block.GetComponent<Image>().color = Color.red;
;

                }
                else if (rand <= 0.2f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "4";
                    block.GetComponent<Image>().color = Color.green;

                }
                else if (rand <= 0.3f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "8";
                    block.GetComponent<Image>().color = Color.blue;
                }
                else if (rand <= 0.4f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "16";

                    block.GetComponent<Image>().color = Color.cyan;
                }
                else if (rand <= 0.5f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "32";
                    block.GetComponent<Image>().color = Color.white;
                }
                else if (rand <= 0.6f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "64";
                    block.GetComponent<Image>().color = Color.magenta;
                }
                else if (rand <= 0.7f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "128";
                    block.GetComponent<Image>().color = Color.gray;
                }
                else if (rand <= 0.8f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "256";
                    block.GetComponent<Image>().color = Color.yellow;
                }
                else if (rand <= 0.9f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "512";
                    block.GetComponent<Image>().color = Color.black;
                }
                else
                {
                block.GetComponentInChildren<TextMeshProUGUI>().text = "1024";
                block.GetComponent<Image>().color = Color.gray;
                }
        }
    }

    public void setscore(int value ,bool end=false)
    {
        Score += value;
        finish = end;

    }
}
