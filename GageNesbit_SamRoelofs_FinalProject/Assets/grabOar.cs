using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class grabOar : MonoBehaviour
{
    private bool hit=false;
    public GameObject  oar;
    private level2Player player;
    public GameObject playerObject;

    public GameObject interactionText;
    public TextMeshProUGUI messageText;

    public GameObject swingingAxe,sittingAxe;

    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<level2Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hit&&Input.GetKeyDown(KeyCode.E)){
            oar.SetActive(false);
            interactionText.SetActive(false);
            player.hasOar=true;
            swingingAxe.SetActive(false);
            sittingAxe.SetActive(false);
            player.hasAxe=false;
        }
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player")){
            messageText.text="Press E to grab oar";
            interactionText.SetActive(true);
            hit=true;
        }
    }
}
