using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class backToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player")){
            SceneManager.LoadScene("Menu");
            PlayerPrefs.SetInt("twoButtonOn", true ? 1 : 0);
        PlayerPrefs.Save();

        }
    }
}
