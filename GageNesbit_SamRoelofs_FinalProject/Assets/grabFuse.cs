using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class grabFuse : MonoBehaviour
{
    private bool hit=false;
    public GameObject fuse;
    private PlayerController player;
    public GameObject playerObject;

    public GameObject interactionText;
    public TextMeshProUGUI messageText;

    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hit&&Input.GetKeyDown(KeyCode.E)){
            fuse.SetActive(false);
            interactionText.SetActive(false);
            player.hasfuse=true;
        }   
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player")){
            messageText.text="Press E to grab fuse";
            interactionText.SetActive(true);
            hit=true;
        }
    }
}
