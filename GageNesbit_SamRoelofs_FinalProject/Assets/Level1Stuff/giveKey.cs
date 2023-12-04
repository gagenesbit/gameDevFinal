using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class giveKey : MonoBehaviour
{
    public TextMeshProUGUI interactionText;
    public GameObject interactionCanvas;
    public bool messageActive=false;
    public bool done=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(messageActive&&Input.GetKeyDown(KeyCode.E)){
            give();
            
            interactionCanvas.SetActive(false);
            interactionText.text="Press e to interact";
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")&&!done)
        {
            Debug.Log("Hit prisoner");
            interactionText.text="'Thank you for freeing me! Here's a key I swiped off a guard'";
            interactionCanvas.SetActive(true);
            messageActive=true;
        }
    }
    private void give(){
        Debug.Log("KEy");
        interactionText.text="Press e to interact";
    }
}
