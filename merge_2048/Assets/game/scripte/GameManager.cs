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
    public TMP_Text high;

    public TMP_Text _score;
    public int _width = 6;
    public int _height = 8;
    public Transform[] cellposarray;
    public bool[] isfree;
    public Transform[,] _cellposlist;
    public GameObject blockprefab;
    public static float Score=0;
    public bool finish;
    public GameObject win;
    public AudioClip endwin;
    public AudioClip endlose;

    int z = 0;
    public GameObject[] numcube;
    public GameObject btn;
    public GameObject btn2;
    bool winsound=true;
    bool losesound = true;
    public GameObject lose;
    void Start()
    {
        GetPosCell(0,8);
    }

    private void Update()
    {
        
        if (finish )
        {
            if (ButtonScript.Score > ButtonScript.highscore)
            {
                ButtonScript.highscore = ButtonScript.Score;
                Debug.Log(Score);
            }
            Debug.Log("Main : " + Score);
            Time.timeScale = 0;
            win.transform.SetAsLastSibling();
            win.SetActive(true);
            if (winsound)
            {
                GetComponent<AudioSource>().PlayOneShot(endwin);
                winsound = false;
            }
            

            high = GameObject.FindGameObjectWithTag("yourscore").GetComponent<TextMeshProUGUI>();
            high.text = "Your Score : " + ButtonScript.Score;
            PlayerPrefs.SetInt("highsc", ButtonScript.highscore);

            btn.SetActive(false);
            btn2.SetActive(false);


        }
        else if (numcube.Length > 40 || ButtonScript.loser)
        {
            if (ButtonScript.Score > ButtonScript.highscore)
            {
                ButtonScript.highscore = ButtonScript.Score;
                Debug.Log(Score);
            }
            Debug.Log("Main : " + Score);
            Time.timeScale = 0;
            lose.transform.SetAsLastSibling();
            lose.SetActive(true);
            if (losesound)
            {
                GetComponent<AudioSource>().PlayOneShot(endlose);
                losesound = false;
            }


            high = GameObject.FindGameObjectWithTag("yourscore").GetComponent<TextMeshProUGUI>();
            high.text = "Your Score : " + ButtonScript.Score;
            PlayerPrefs.SetInt("highsc",ButtonScript.highscore);

            btn.SetActive(false);
            btn2.SetActive(false);
            ButtonScript.loser = false;
        }
        else
        {
            Time.timeScale = 1;
        }

        numcube = GameObject.FindGameObjectsWithTag("block");
    }


    public void GetPosCell(int start,int value)
    {
        
        

        var center = new Vector2((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f);
        Camera.main.transform.position = new Vector3(center.x, center.y, -10);


        
        for (int i = start; i < value; i++)
        {
                float rand = Random.value;
                
                GameObject block = Instantiate(blockprefab, cellposarray[i]);
                block.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                if (rand <= 0.15f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "2";
                    block.GetComponent<Image>().color = Color.red;
;

                }
                else if (rand <= 0.3f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "4";
                    block.GetComponent<Image>().color = Color.green;

                }
                else if (rand <= 0.45f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "8";
                    block.GetComponent<Image>().color = Color.blue;
                }
                else if (rand <= 0.6f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "16";

                    block.GetComponent<Image>().color = Color.cyan;
                }
                else if (rand <= 0.75f)
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "32";
                    block.GetComponent<Image>().color = Color.white;
                }
                else
                {
                    block.GetComponentInChildren<TextMeshProUGUI>().text = "64";
                    block.GetComponent<Image>().color = Color.magenta;
                }
               /* else if (rand <= 0.7f)
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
                }*/
                /*else
                {
                block.GetComponentInChildren<TextMeshProUGUI>().text = "128";
                block.GetComponent<Image>().color = Color.gray;
                }*/
        }
    }

    public void setscore(int value ,bool end=false)
    {
        Score += value;
        finish = end;
    }
    public void newblocks()
    {
            GetPosCell(40,48);
               
    }
}
