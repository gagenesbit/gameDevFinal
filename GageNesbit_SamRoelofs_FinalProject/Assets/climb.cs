using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class climb : MonoBehaviour
{   public GameObject interactionText;
    public TextMeshProUGUI messageText;

    private PlayerController player;
    public GameObject playerObject;

    private bool collide=false;
    private bool moveUpBool= false;
    private bool madeItToTop=false;
    private bool backDown=false,goDown=false;
    public GameObject blackPowder;
    private bool done=false;

    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!done){
            if(collide&&Input.GetKeyDown(KeyCode.E))
            {
                
                moveUpBool=true;
                playerObject.GetComponent<Rigidbody>().useGravity = false;
            }
            if(moveUpBool){
                moveUp();
            }
            if(madeItToTop&&Input.GetKeyDown(KeyCode.E)){
        
                grabBlackPowder();
            }
            if(backDown&&Input.GetKeyDown(KeyCode.E)){
                moveDown();
            }
            if(goDown){
                moveDown();
            }
        }
        
    }

     void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player")){
            player.puzzleActive=true;
            Debug.Log("ladder");
            collide=true;
            messageText.text="Press E to climb ladder";
            interactionText.SetActive(true);
        }
     }
    private void moveUp(){
            
            interactionText.SetActive(false);
            messageText.text="Press E to pick up black powder, and go back down";
            if(playerObject.transform.position.y<27.0f){
                playerObject.transform.Translate(Vector3.up * 2.0f * Time.deltaTime);
            }
            else{
                //playerObject.transform= new Vector3(3.8f, 2.14f, -13.76f);
                interactionText.SetActive(true);
                moveUpBool=false;
                madeItToTop=true;
           }
     }
     private void moveDown(){
        goDown=true;
        interactionText.SetActive(false);
        if(playerObject.transform.position.y>6.75f){
                playerObject.transform.Translate(Vector3.down * 2.0f * Time.deltaTime);
        }
        else{
            playerObject.GetComponent<Rigidbody>().useGravity = true;
            done=true;
            player.puzzleActive=false;
        }
     }
     private void grabBlackPowder(){
        blackPowder.SetActive(false);
        player.hasBlackPowder=true;
        messageText.text="Press E to go back down";
        backDown=true;

     }
}
