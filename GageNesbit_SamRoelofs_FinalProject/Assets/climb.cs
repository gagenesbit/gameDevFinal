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
    private bool move= false;
    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(collide&&Input.GetKeyDown(KeyCode.E))
        {
            
            move=true;
            playerObject.GetComponent<Rigidbody>().useGravity = false;
        }
        if(move){
            moveUp();
        }
    }

     void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player")){
            collide=true;
            messageText.text="Press E to climb ladder";
            interactionText.SetActive(true);
        }
     }
     void moveUp(){
            if(playerObject.transform.position.y<28.0f){
                playerObject.transform.Translate(Vector3.up * 2.0f * Time.deltaTime);
            }
            else if(playerObject.transform.position.z<2.35f){
                playerObject.transform.Translate(Vector3.forward * 2.0f * Time.deltaTime);
            }
            else{
                playerObject.GetComponent<Rigidbody>().useGravity = true;
            }
     }
}
