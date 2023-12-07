using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dropCoconut : MonoBehaviour
{
    public GameObject interactionText;
    public TextMeshProUGUI messageText;
    private bool hit;


    private level2Player player;
    public GameObject playerObject;
    
    //public GameObject coconut;
    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<level2Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hit&&Input.GetKeyDown(KeyCode.E)){
            gameObject.SetActive(false);
            interactionText.SetActive(false);
            player.hasCoconut=true;
        }
      
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Plank")){
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;  
        }
        else if(collision.gameObject.CompareTag("Player")){
            messageText.text="Press E to grab coconuts";
            interactionText.SetActive(true);
            hit=true;
        }
    }
}
