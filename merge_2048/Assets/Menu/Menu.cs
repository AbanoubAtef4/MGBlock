using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject option;
    public GameObject start;
    public GameObject rule;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void play_button()
    {
        SceneManager.LoadScene(1);
    }

    public void option_button()
    {
        option.SetActive(true);
        start.SetActive(false);
    }
    public void back_button()
    {
        option.SetActive(false);
        start.SetActive(true);
    }

    public void exit_button()
    {
        Application.Quit();
    }
    public void rule_button()
    {
        rule.SetActive(true);
        start.SetActive(false);
    }
}
