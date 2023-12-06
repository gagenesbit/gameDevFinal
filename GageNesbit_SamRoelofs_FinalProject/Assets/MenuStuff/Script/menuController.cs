using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu, settings, credits, levels, audio;
    public GameObject levelTwoButton;
    void Start()
    {
        mainOpen();
    }

    public void playOne()
    {
        //levelTwoButton.SetActive(true);
        //PlayerPrefs.SetInt("twoButtonOn", levelTwoButton.activeSelf ? 1 : 0);
        //PlayerPrefs.Save();
        //levelTwoButton.SetActive(false);
        SceneManager.LoadScene("LevelOne");
    }

    public void playTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void musicToggle()
    {
        Debug.Log("Music Toggle");
        audio.SetActive(!audio.activeSelf);
    }

    public void mainOpen()
    {
        turnAllOff();
        mainMenu.SetActive(true);
        levelTwoButton.SetActive(PlayerPrefs.GetInt("twoButtonOn", 0) == 1);;
    }

    public void levelSelectOpen()
    {
        turnAllOff();
        levels.SetActive(true);
    }

    public void settingsOpen()
    {
        turnAllOff();
        settings.SetActive(true);
    }

    public void creditsOpen()
    {
        turnAllOff();
        credits.SetActive(true);
    }

    private void turnAllOff()
    {
        credits.SetActive(false);
        settings.SetActive(false);
        mainMenu.SetActive(false);
        levels.SetActive(false);
    }

    public void reset()
    {
        levelTwoButton.SetActive(false);
        PlayerPrefs.SetInt("twoButtonOn", levelTwoButton.activeSelf ? 1 : 0);
        PlayerPrefs.Save();
    }

    
}
