using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class codePuzzle : MonoBehaviour
{
    public GameObject interactionText;
    public TMP_Text codeText;
    public GameObject keypad;
    private PlayerController player;
    public GameObject playerObject;
    private Canvas canvas;
    private string CODE="1234";
   
    // Start is called before the first frame update
    void Start()
    {
        // Make sure to use playerObject, not player
        player = playerObject.GetComponent<PlayerController>();
        canvas = keypad.GetComponent<Canvas>();
        //canvas.enabled=false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionText == true && Input.GetKeyDown(KeyCode.E) && player != null && player.puzzleCode == 1)
        {
            puzzle();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a specific tag
        if (collision.gameObject.CompareTag("Player"))
        {
            interactionText.SetActive(true);
        }
    }

    private void puzzle()
    {
        player.puzzleActive=true;
        Debug.Log("Trigger hit");
        interactionText.SetActive(false);
        keypad.SetActive(true);
        //canvas.enabled=false;
    }

    public void enterCode(){
        if(CODE.Equals(codeText.text)){

        }
    }
    public void type(string s){

    }
}
