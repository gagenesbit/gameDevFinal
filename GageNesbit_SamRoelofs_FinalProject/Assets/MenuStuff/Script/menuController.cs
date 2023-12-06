using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu,settings, credits, levels, audio;
    public GameObject levelTwoButton;
    private bool level1Completed=false;

    void Start()
    {

        mainOpen();
    }
    
    public void playOne(){
        SceneManager.LoadScene("LevelOne");
    }
    public void playTwo(){
        SceneManager.LoadScene("LevelTwo");
    }

    public void musicToggle(){
        Debug.Log("Music Toggle");
        if(audio.activeSelf){
            audio.SetActive(false);
        }
        else{
            audio.SetActive(true);
        }
    }


    public void mainOpen(){
        turnAllOff();
        mainMenu.SetActive(true);
    }

    public void levelSelectOpen(){
        turnAllOff();
        levels.SetActive(true);

    }

    public void settingsOpen(){
        turnAllOff();
        settings.SetActive(true);
    }

    public void creditsOpen(){
        turnAllOff();
        credits.SetActive(true);
    }

    private void turnAllOff(){
        credits.SetActive(false);
        settings.SetActive(false);
        settings.SetActive(false);
        mainMenu.SetActive(false);
    }

}
