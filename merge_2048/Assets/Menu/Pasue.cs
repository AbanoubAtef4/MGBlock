using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Pasue : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pasue;
    public GameObject option;
    ///public AudioMixer audiosound;
    private bool stopgame = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (stopgame)
            {
                resume_button();
            }
            else
            {
                pasue_menu();
            }
        }
    }

    public void resume_button()
    {
        pasue.SetActive(false);
        Time.timeScale = 1;
        stopgame = false;
    }
    public void pasue_menu()
    {
        pasue.SetActive(true);
        Time.timeScale = 0;
        stopgame = true;
    }

    public void restart_button()
    {
        SceneManager.LoadScene(1);
    }
    
    public void option_button()
    {
        option.SetActive(true);
        pasue.SetActive(false);

    }

    public void back_button()
    {
        option.SetActive(false);
        pasue.SetActive(true);

    }

    public void mainmenu_button()
    {
        SceneManager.LoadScene(0);
    }

    
    // Update is called once per frame
    

    
}
