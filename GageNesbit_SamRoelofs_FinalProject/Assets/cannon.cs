using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cannon : MonoBehaviour
{
    private PlayerController player;
    public GameObject playerObject;
    private bool fusePlaced=false,blackPowderPlaced=false;
    public PlayerController litParticles;
    private bool fuseMessage,blackPowderMessage,enterMessage;
    private bool launchTime;
    private Rigidbody playerRB;
    
    public GameObject interactionText;

    
    public TextMeshProUGUI messageText;
    private bool FIRED;
    private bool done;

    public GameObject fuseObject;


    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<PlayerController>();
        playerRB=playerObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {  
        if(fusePlaced&&fuseObject.activeSelf==false){
            fuseObject.SetActive(true);
        }
         if(!launchTime){
            if(Input.GetKeyDown(KeyCode.E)){
                if(blackPowderMessage){
                    player.hasBlackPowder=false;
                    blackPowderPlaced=true;
                    blackPowderMessage=false;
                }
                else if(fuseMessage){
                    player.hasfuse=false;
                    fusePlaced=true;
                    fuseMessage=false;
                }
                else if(enterMessage){
                    Debug.Log("Cannon Ready");
                    enterMessage=false;
                    launchTime=true;
                }
                interactionText.SetActive(false);

            }
        }
        else{
            launch();
        }
        
        /*if(blackPowderMessage&&)
        litParticles.SetActive(true);
        player.hasBlackPowder=false;
                blackPowderPlaced=true;*/
    }
    void OnCollisionEnter(Collision collision){
    if (collision.gameObject.CompareTag("Player")){
        if(player.hasBlackPowder){
            messageText.text="Press E to place black powder in the cannon";
            blackPowderMessage=true;
            interactionText.SetActive(true);
        }
        else if(player.hasfuse){
            messageText.text="Press E to place the fuse in the cannon";
            fuseMessage=true;
            interactionText.SetActive(true);
        }
        else if(fusePlaced&&blackPowderPlaced){
            messageText.text="Press E to get in the cannon";
            enterMessage=true;
            interactionText.SetActive(true);
        }
        else{
            messageText.text="NOTHING";
            interactionText.SetActive(true);
        }
    }
}

    private void launch(){
        if(FIRED){
            //playerObject.transform.Translate(Vector3.forward * 5.0f * Time.deltaTime);
            playerRB.AddForce(player.transform.forward * 50f, ForceMode.Impulse);
            playerRB.AddForce(player.transform.up * 10f, ForceMode.Impulse);
            FIRED=!FIRED;
            done=true;
        }
        else if(done){

        }
        else{
            playerRB.useGravity = false;
            playerObject.transform.position=new Vector3(9.2f, 12.99f, -13.41f);
            messageText.text="Press E to fire";
            interactionText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
                playerRB.useGravity=true;
                FIRED=true;
                interactionText.SetActive(false);
            }
        }
        

    }
}
