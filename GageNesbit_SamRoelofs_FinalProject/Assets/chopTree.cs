using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chopTree : MonoBehaviour
{
    public GameObject oar;
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = oar.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player")){
            rb.useGravity = true;
            gameObject.SetActive(false);
        }
    }
}
