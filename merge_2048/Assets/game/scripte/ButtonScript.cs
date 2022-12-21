using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour,IBeginDragHandler,IPointerDownHandler,IEndDragHandler,IDragHandler
{
    public TMP_Text txt;
    public static int Score = 0;
    RectTransform rect;
    Cells check;
    CanvasGroup cg;
    bool down = false;
    Rigidbody2D rg;
    GameManager init;
    public float highscore = 0;
    public AudioSource merge;
    GameObject per;
    private void Start() {
        check = GetComponent<Cells>();
        rect = GetComponent<RectTransform>();
        cg = GetComponent<CanvasGroup>();
        rg = GetComponent<Rigidbody2D>();
        init = GameObject.Find("GameManager").GetComponent<GameManager>();
        highscore = PlayerPrefs.GetFloat("highscore");
        merge = GetComponent<AudioSource>();
        //StartCoroutine(Parent());
        Score = 0;
    }

    private void Update() {

    
    }  
      public void OnBeginDrag(PointerEventData d){
        //if (check.up !=null && check.right != null && check.left != null)
        //{
        rg.bodyType = RigidbodyType2D.Kinematic;
            cg.blocksRaycasts = false;

        //}
            
      }
      public void OnDrag(PointerEventData d){

            rect.anchoredPosition += d.delta;
      }
      public void OnEndDrag(PointerEventData d){
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        cg.blocksRaycasts = true;
        rg.bodyType = RigidbodyType2D.Dynamic;

    }

    public void OnPointerDown(PointerEventData d) 
      {

      }

    
    //private void OnTriggerStay2D(Collider2D collision)
    //{

    //    if (gameObject.tag==collision.gameObject.tag)
    //    {


    //        string num1 = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;

    //        string num2 = collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;


    //        if (num1 == num2)
    //        {
    //            down = true;
    //            if (num1 == "2")
    //            {
    //                collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "4";
    //                collision.gameObject.GetComponent<Image>().color = Color.green;
    //                Score += 2;
    //                init.setscore(Score);
    //                Debug.Log(highscore);

    //            }
    //            else if (num1 == "4")
    //            {

    //                collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "8";
    //                collision.gameObject.GetComponent<Image>().color = Color.blue;
    //                Score += 4;
    //                init.setscore(Score);
    //                Debug.Log(highscore);

    //            }
    //            else if (num1 == "8")
    //            {

    //                collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "16";
    //                collision.gameObject.GetComponent<Image>().color = Color.cyan;
    //                Score += 8;
    //                init.setscore(Score);
    //                Debug.Log(highscore);

    //            }
    //            else if (num1 == "16")
    //            {

    //                collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "32";
    //                collision.gameObject.GetComponent<Image>().color = Color.white;
    //                Score += 16;
    //                init.setscore(Score);
    //                Debug.Log(highscore);

    //            }
    //            else if (num1 == "32")
    //            {

    //                collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "64";
    //                collision.gameObject.GetComponent<Image>().color = Color.magenta;
    //                Score += 32;
    //                init.setscore(Score);
    //                Debug.Log(highscore);

    //            }
    //            else if (num1 == "64")
    //            {

    //                collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "128";
    //                collision.gameObject.GetComponent<Image>().color = Color.gray;
    //                Score += 64;
    //                init.setscore(Score);
    //                Debug.Log(highscore);

    //            }
    //            else if (num1 == "128")
    //            {

    //                collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "256";
    //                collision.gameObject.GetComponent<Image>().color = Color.yellow;
    //                Score += 128;
    //                init.setscore(Score);
    //                Debug.Log(highscore);

    //            }
    //            else if (num1 == "256")
    //            {

    //                collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "512";
    //                collision.gameObject.GetComponent<Image>().color = Color.black;
    //                Score += 256;
    //                init.setscore(Score);
    //                Debug.Log(highscore);

    //            }
    //            else if (num1 == "512")
    //            {

    //                collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "1024";
    //                collision.gameObject.GetComponent<Image>().color = Color.gray;
    //                Score += 512;
    //                init.setscore(Score);
    //                Debug.Log(highscore);

    //            }
    //            else if (num1 == "1024")
    //            {

    //                collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "2048";
    //                collision.gameObject.GetComponent<Image>().color = new Color(51, 51, 0);
    //                Score += 1024;
    //                if (Score > highscore)
    //                {
    //                    highscore = Score;
    //                    PlayerPrefs.SetFloat("highscore", highscore);

    //                    Debug.Log(highscore);
    //                }
    //                Debug.Log(highscore);

    //                init.setscore(Score, true);

    //            }
    //            merge.Play();
    //            Destroy(gameObject);
    //        }
    //        else
    //        {
    //            //init.GetPosCell();
    //        }
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == collision.gameObject.tag)
        {


            string num1 = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;

            string num2 = collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;


            if (num1 == num2)
            {
                down = true;
                if (num1 == "2")
                {
                    collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "4";
                    collision.gameObject.GetComponent<Image>().color = Color.green;
                    Score += 2;
                    init.setscore(Score);
                    Debug.Log(highscore);

                }
                else if (num1 == "4")
                {

                    collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "8";
                    collision.gameObject.GetComponent<Image>().color = Color.blue;
                    Score += 4;
                    init.setscore(Score);
                    Debug.Log(highscore);

                }
                else if (num1 == "8")
                {

                    collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "16";
                    collision.gameObject.GetComponent<Image>().color = Color.cyan;
                    Score += 8;
                    init.setscore(Score);
                    Debug.Log(highscore);

                }
                else if (num1 == "16")
                {

                    collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "32";
                    collision.gameObject.GetComponent<Image>().color = Color.white;
                    Score += 16;
                    init.setscore(Score);
                    Debug.Log(highscore);

                }
                else if (num1 == "32")
                {

                    collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "64";
                    collision.gameObject.GetComponent<Image>().color = Color.magenta;
                    Score += 32;
                    init.setscore(Score);
                    Debug.Log(highscore);

                }
                else if (num1 == "64")
                {

                    collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "128";
                    collision.gameObject.GetComponent<Image>().color = Color.gray;
                    Score += 64;
                    init.setscore(Score);
                    Debug.Log(highscore);

                }
                else if (num1 == "128")
                {

                    collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "256";
                    collision.gameObject.GetComponent<Image>().color = Color.yellow;
                    Score += 128;
                    init.setscore(Score);
                    Debug.Log(highscore);

                }
                else if (num1 == "256")
                {

                    collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "512";
                    collision.gameObject.GetComponent<Image>().color = Color.black;
                    Score += 256;
                    init.setscore(Score);
                    Debug.Log(highscore);

                }
                else if (num1 == "512")
                {

                    collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "1024";
                    collision.gameObject.GetComponent<Image>().color = Color.gray;
                    Score += 512;
                    init.setscore(Score);
                    Debug.Log(highscore);

                }
                else if (num1 == "1024")
                {

                    collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "2048";
                    collision.gameObject.GetComponent<Image>().color = new Color(51, 51, 0);
                    Score += 1024;
                    if (Score > highscore)
                    {
                        highscore = Score;
                        PlayerPrefs.SetFloat("highscore", highscore);
                        Debug.Log(highscore);
                    }

                    init.setscore(Score, true);

                }



                Destroy(gameObject);
            }
            else
            {
                //init.GetPosCell(8);
            }
        }
        

    }


    /*IEnumerator Parent()
    {

        yield return new WaitForSeconds(0.2f);
        transform.SetParent(GameObject.FindWithTag("Player").transform);

    }
    */
}
