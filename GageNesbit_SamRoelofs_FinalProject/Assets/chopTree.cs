using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chopTree : MonoBehaviour
{
    public GameObject oar;
    public Rigidbody rb;

    private level2Player player;
    public GameObject playerObject;

    public GameObject swingingAxe;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = oar.GetComponent<Rigidbody>();
        rb.useGravity = false;
        player=playerObject.GetComponent<level2Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player")){
            if (player.hasAxe){
                rb.useGravity = true;
                gameObject.SetActive(false);
                player.hasAxe=false;
                swingingAxe.SetActive(false);
            }
        }
    }
}
