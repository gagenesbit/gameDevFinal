using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class colorPuzzleController : MonoBehaviour
{
    public GameObject interactionText;
    public TextMeshProUGUI messageText;
    public bool holdingCube=false;

    //Interact with player script
    private PlayerController player;
    public GameObject playerObject;

    public GameObject falseWall;
    public GameObject redCube;
    private GameObject currentCube;
    private bool redPlaced;
    private bool done=false;
    private int wrong=0, move=0;
    private colorPuzzleController scriptComponent;


    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<PlayerController>();
        scriptComponent = GetComponent<colorPuzzleController>();
    }

    // Update is called once per frame
    void Update()
    {   if(!done &&redPlaced){
            
            wrong++;
            if(wrong>100){
                reset();
                Debug.Log("Block Reset");
            }
        }
        else if(!done){
            if(!player.barrel.Equals("")){
                messageText.text="Press E to place a cube";
                interactionText.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.E)&&!holdingCube&&messageText.text=="Press E to pick up a cube"){
                Debug.Log("Picking UP");
                pickUpCube();
                

            }
            else if(Input.GetKeyDown(KeyCode.E)&&holdingCube&&!player.barrel.Equals("")){
                Debug.Log("ready to place");
                placeCube();
            }
        }
        else{
            interactionText.SetActive(false);
            if(move<2000){
                falseWall.transform.Translate(Vector3.forward * -1f * Time.deltaTime);
                move++;
            }
            else if(move==2000){
                messageText.text="Press E to interact";
                scriptComponent.enabled=false;
            }
        }

        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        // Check if the colliding object has a specific tag
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(messageText.text);
            messageText.text="Press E to pick up a cube";
            interactionText.SetActive(true);
        }
    }


    private void pickUpCube(){
        interactionText.SetActive(false);
        if(!redPlaced){
            redCube.SetActive(false);
            currentCube=redCube;
        }
        holdingCube=true;
    }

    private void placeCube(){
        if(player.barrel.Equals("red")){
            currentCube.SetActive(true);
            currentCube.transform.position = new Vector3(3.8f, 2.14f, -13.76f);
            redPlaced=true;
            done=true; 
        }
        else if(player.barrel.Equals("green")){
            currentCube.SetActive(true);
            currentCube.transform.position = new Vector3(3.8f, 2.14f, -11.28f);
            redPlaced=true;
        }

        else if(player.barrel.Equals("white")){
            currentCube.SetActive(true);
            currentCube.transform.position = new Vector3(3.8f, 2.14f, -12.59f);
            redPlaced=true;
        } 

        holdingCube=false;
        
    }
    
    public void reset(){
        wrong=0;
        currentCube.transform.position = new Vector3(-1.658f, 2.417f, -15.381f);
        messageText.text="";
        interactionText.SetActive(false);
        holdingCube=false;
        done=false;
        redPlaced=false;
        player.barrel="";
    }

}
