using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
