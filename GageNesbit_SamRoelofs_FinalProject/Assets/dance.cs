using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dance : MonoBehaviour
{
     private PlayerController player;
    public GameObject playerObject;

    private bool dancing;
    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.yellowKey&&!dancing){
            dancing=true;
        }
    }

}
