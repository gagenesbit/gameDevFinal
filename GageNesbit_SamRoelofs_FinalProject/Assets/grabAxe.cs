using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class grabAxe : MonoBehaviour
{
    private bool hit=false;
    public GameObject swingingAxe, sittingAxe;
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
            swingingAxe.SetActive(true);
            sittingAxe.SetActive(false);
            interactionText.SetActive(false);
            player.hasAxe=true;
        }
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player")){
            messageText.text="Press E to grab axe";
            interactionText.SetActive(true);
            hit=true;
        }
    }
}
