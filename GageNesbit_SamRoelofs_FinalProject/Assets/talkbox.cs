using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class talkbox : MonoBehaviour
{

    private level2Player player;
    public GameObject playerObject;

    private bool coconutMessage, oarMessage, sailMessage, woodMessage = false;
    private bool coconutGiven, oarGiven, sailGiven, woodGiven = false;

    public GameObject interactionText;
    public TextMeshProUGUI messageText;

    public GameObject coconuts;

    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<level2Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(coconutMessage){
                player.hasCoconut=false;
                coconutGiven=true;
                coconutMessage=false;
            }
            else if(oarMessage){
                player.hasOar=false;
                oarGiven=true;
                oarMessage=false;
            }
            else if(sailMessage){
                player.hasSail=false;
                sailGiven=true;
                sailMessage=false;
            }
            else if(woodMessage){
                player.hasWood=false;
                woodGiven=true;
                woodMessage=false;
            }
            interactionText.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player")){
            
            if(!coconutGiven){
                if(player.hasCoconut){
                    messageText.text="Press E to give Mouse the coconut";
                    coconutMessage=true;
                    interactionText.SetActive(true);
                }
                else{
                    messageText.text="I'm so hungry, bring me a coconut.";
                    interactionText.SetActive(true);
                }
            }
            else{
                coconuts.SetActive(true);

                if(player.hasOar){
                    messageText.text="Press E to give Mouse the oar";
                    oarMessage=true;
                    interactionText.SetActive(true);
                }
                else if(player.hasSail){
                    messageText.text="Press E to give Mouse the sail";
                    sailMessage=true;
                    interactionText.SetActive(true);
                }
                else if(player.hasWood){
                    messageText.text="Press E to give Mouse the wood";
                    woodMessage=true;
                    interactionText.SetActive(true);
                }
                else if(oarGiven&&woodGiven&&sailGiven){
                    player.raftComplete=true;
                }
                else{
                    messageText.text="Bring me an oar, a sail, and some wood.";
                    interactionText.SetActive(true);
                }
            }
        }
    }

    void OnCollisionExit(Collision collision){
        if (collision.gameObject.CompareTag("Player")){
            interactionText.SetActive(false);
        }
    }
}
