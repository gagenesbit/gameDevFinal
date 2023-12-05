using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class waterControl : MonoBehaviour
{
    public GameObject interactionText;
    public TextMeshProUGUI messageText;
    public GameObject waterParticles;
    private bool hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hit&&Input.GetKeyDown(KeyCode.E)){
            waterParticles.SetActive(true);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a specific tag
        if (collision.gameObject.CompareTag("Player"))
        {
            messageText.text="Press E to turn on the water";
            interactionText.SetActive(true);
            hit=true;
        }
    }
}
