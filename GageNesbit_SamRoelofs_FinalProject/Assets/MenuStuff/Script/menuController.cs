using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    
    public void playOne(){
        SceneManager.LoadScene("LevelOne");
    }
    public void playTwo(){
        SceneManager.LoadScene("LevelTwo");
    }
    public void musicToggle(){
        Debug.Log("Music Toggle");
    }
}
