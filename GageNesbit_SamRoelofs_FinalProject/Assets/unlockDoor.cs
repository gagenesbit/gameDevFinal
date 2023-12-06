using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockDoor : MonoBehaviour
{
    public GameObject orangeLock,purpleLock,yellowLock;
    private bool purple,yellow,orange;
    private PlayerController player;
    public GameObject playerObject;
    public GameObject leftDoor,rightDoor;
    private int done=0,rotVal=900;
    public bool test;
    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if((purple&&yellow&&orange&&done<rotVal)||test&&done<rotVal){
            Debug.Log("DOOR OPEN");
            done++;
            leftDoor.transform.Rotate(Vector3.up, -20.0f * Time.deltaTime);
            rightDoor.transform.Rotate(Vector3.up, 20.0f * Time.deltaTime);
            if(rotVal==done){
                gameObject.SetActive(false);
            }


        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a specific tag
        if (collision.gameObject.CompareTag("Player"))
        {
            if(player.yellowKey){
                yellowLock.SetActive(false);
                yellow=true;
                player.yellowKey=false;
            }
            if(player.orangeKey){
                orangeLock.SetActive(false);
                orange=true;
                player.orangeKey=false;
            }
            if(player.purpleKey){
                purpleLock.SetActive(false);
                purple=true;
                player.purpleKey=false;
            }
        }
    }

  


}
