using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class grabRaftBase : MonoBehaviour
{
    private bool hit=false;
    public GameObject  raftBase;
    private level2Player player;
    public GameObject playerObject;

    public GameObject interactionText;
    public TextMeshProUGUI messageText;

    

    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<level2Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hit&&Input.GetKeyDown(KeyCode.E)){
            raftBase.SetActive(false);
            interactionText.SetActive(false);
            player.hasWood=true;
            player.puzzleActive=false;
        }
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player")){
            player.puzzleActive=true;
            messageText.text="Press E to grab wood for the raft";
            interactionText.SetActive(true);
            hit=true;
        }
    }
}
