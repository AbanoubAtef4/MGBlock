using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour,IBeginDragHandler,IPointerDownHandler,IEndDragHandler,IDragHandler
{
    public TMP_Text txt;
    public TMP_Text totalScore;
    public static bool loser = false;
    public static int Score = 0;
    RectTransform rect;
    Cells check;
    CanvasGroup cg;
    bool down = false;
    Rigidbody2D rg;
    GameManager init;
    public static int highscore = 0;
    public AudioClip merge;
    public bool drag = false;
    public bool wrong = false;
    GameObject per;
    public int _wrong = 0;
    bool merging = true;
    public bool flag = false; 
    private void Start() {
        check = GetComponent<Cells>();
        rect = GetComponent<RectTransform>();
        cg = GetComponent<CanvasGroup>();
        rg = GetComponent<Rigidbody2D>();
        init = GameObject.Find("GameManager").GetComponent<GameManager>();
        highscore = PlayerPrefs.GetInt("highsc");
        StartCoroutine(Parent());
        StartCoroutine(gameover());
        totalScore = GameObject.FindWithTag("score").GetComponent<TextMeshProUGUI>();


    }

    private void Update() {
        if (drag)
        {


            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9, 12),
            Mathf.Clamp(transform.position.y, -6, 9),
            transform.position.z);
            
        }

       
        

    }
    public void OnBeginDrag(PointerEventData d){
        
            rg.bodyType = RigidbodyType2D.Kinematic;
            cg.blocksRaycasts = false;
            drag = true;
            _wrong = 0;
        wrong = false;
        flag = false;
            
      }
      public void OnDrag(PointerEventData d){

            rect.anchoredPosition += d.delta;
      }
      public void OnEndDrag(PointerEventData d){
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        cg.blocksRaycasts = true;
        rg.bodyType = RigidbodyType2D.Dynamic;
        wrong = true;
        StartCoroutine(gameover());


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
    //            
    //            Destroy(gameObject);
    //        }
    //        else
    //        {
    //            //init.GetPosCell();
    //        }
    //    }
    //}
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (gameObject.tag == collision.gameObject.tag)
        {


            string num1 = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;

            string num2 = collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;

            

            if (num1 == num2)
            {
                _wrong += 1;
                down = true;
                if (num1 == "2")
                {
                    gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "4";
                    gameObject.GetComponent<Image>().color = Color.green;
                    Score += 2;
                    init.setscore(Score);
                    Debug.Log(Score);
                    

                }
                else if (num1 == "4")
                {

                    gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "8";
                    gameObject.GetComponent<Image>().color = Color.blue;
                    Score += 4;
                    init.setscore(Score);
                    Debug.Log(Score);
                }
                else if (num1 == "8")
                {

                    gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "16";
                    gameObject.GetComponent<Image>().color = Color.cyan;
                    Score += 8;
                    init.setscore(Score);
                    Debug.Log(Score);
                }
                else if (num1 == "16")
                {

                    gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "32";
                    gameObject.GetComponent<Image>().color = Color.white;
                    Score += 16;
                    init.setscore(Score);
                    Debug.Log(Score);
                }
                else if (num1 == "32")
                {

                    gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "64";
                    gameObject.GetComponent<Image>().color = Color.magenta;
                    Score += 32;
                    init.setscore(Score);
                    Debug.Log(Score);
                }
                else if (num1 == "64")
                {

                    gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "128";
                    gameObject.GetComponent<Image>().color = Color.gray;
                    Score += 64;
                    init.setscore(Score);
                    Debug.Log(Score);
                }
                else if (num1 == "128")
                {

                    gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "256";
                    gameObject.GetComponent<Image>().color = Color.yellow;
                    Score += 128;
                    init.setscore(Score);
                    Debug.Log(Score);
                }
                else if (num1 == "256")
                {

                    gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "512";
                    gameObject.GetComponent<Image>().color = Color.black;
                    Score += 256;
                    init.setscore(Score);
                    Debug.Log(Score);
                }
                else if (num1 == "512")
                {

                    gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "1024";
                    gameObject.GetComponent<Image>().color = Color.gray;
                    Score += 512;
                    init.setscore(Score);
                    Debug.Log(Score);
                }
                else if (num1 == "1024")
                {

                    gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "2048";
                    gameObject.GetComponent<Image>().color = new Color(51, 51, 0);
                    Score += 1024;
                    if (Score > highscore)
                    {
                        highscore = Score;
                        Debug.Log(Score);
                    }

                    init.setscore(Score, true);
                }


                GetComponent<AudioSource>().PlayOneShot(merge);
                totalScore.text = "Score : " + Score.ToString();
                Destroy(collision.gameObject);
                merging = false;
            }
            else
            {
                merging = true;
                if (wrong && _wrong < 1 && merging)
                {
                    Debug.Log("AAAAAAAAAAA");
                    init.newblocks();
                    wrong = false;
                }
            }
            
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag != collision.gameObject.tag)
        {

            
        }
    }
    IEnumerator Parent()
    {

        yield return new WaitForSeconds(0.2f);
        transform.SetParent(GameObject.FindWithTag("Player").transform);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "loser" && flag)
        {
            loser = true;
        }

    }
    IEnumerator gameover()
    {

        yield return new WaitForSeconds(1f);
        flag = true;

    }

}
