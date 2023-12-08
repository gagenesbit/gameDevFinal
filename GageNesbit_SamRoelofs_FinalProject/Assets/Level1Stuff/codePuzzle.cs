using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class codePuzzle : MonoBehaviour
{
    public GameObject yellowKey;
    public GameObject interactionText;
    public GameObject keypad;
    private PlayerController player;
    public GameObject playerObject;
    private string CODE="2023";
    private int completed=0;
    private int redo=0;
    private int rotation=0;
    private bool disabled=false;
    private bool codeTime;

    public TextMeshProUGUI buttonText;
   
    // Start is called before the first frame update
    void Start()
    {
        // Make sure to use playerObject, not player
        player = playerObject.GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!disabled){

            if (interactionText == true && Input.GetKeyDown(KeyCode.E)&&codeTime){
                puzzle();
            }

            if(buttonText.text.Equals("Valid")){
                completed++;
            }
            else if(buttonText.text.Equals("Invalid")){
                redo++;
            }
            if(redo==96){
                buttonText.text="";
                redo=0;
            }
            else if(completed==96){
                complete();
                if (rotation<2400){
                    if(!player.yellowKey&&!yellowKey.activeSelf){
                        yellowKey.SetActive(true);
                        codeTime=false;
                    }
                    transform.Rotate (new Vector3 (0, 20, 0) * Time.deltaTime);
                    rotation++;
                }
                
            }
        }
        

    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a specific tag
        if (collision.gameObject.CompareTag("Player")&&completed==0)
        {
            //keypad.SetActive(true);
            interactionText.SetActive(true);
            codeTime=true;
        }
    }

    private void puzzle()
    {
        player.puzzleActive=true;
        Debug.Log("Trigger hit");
        interactionText.SetActive(false);
        keypad.SetActive(true);
    }

    public void enterCode(){
        if(CODE.Equals(buttonText.text)){
            buttonText.text="Valid";
        }
        else{
            buttonText.text="Invalid";
        }
    }

    public void type(string s){
        
        if(buttonText.text.Length<5){
            buttonText.text=buttonText.text+s;
        }
        
    }

    private void complete(){
        keypad.SetActive(false);
        player.puzzleActive=false;
        buttonText.text="Done";
    }
}