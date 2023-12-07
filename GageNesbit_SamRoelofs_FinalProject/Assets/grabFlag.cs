using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class grabFlag : MonoBehaviour
{
    public GameObject flag;
    private level2Player player;
    public GameObject playerObject;

    public GameObject interactionText;
    public TextMeshProUGUI messageText;

    private bool flagDown,hit;
    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<level2Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hit&&!flagDown){
            lowerFlag();
        }
        
        else if(flagDown){
            messageText.text="Press E to grab flag";
            //done condition
            if(Input.GetKeyDown(KeyCode.E)){
                interactionText.SetActive(false);
                player.puzzleActive=false;
                flag.SetActive(false);
                GetComponent<grabFlag>().enabled=false;
                player.hasSail=true;
            }
        }
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player")&&!flagDown){
            player.puzzleActive=true;
            messageText.text="LoweringFlag";
            interactionText.SetActive(true);
            hit=true;
        }
    }

    private void lowerFlag(){
        if(flag.transform.position.y>29.3f){
                flag.transform.Translate(Vector3.forward * -2.0f * Time.deltaTime);
        }
        else{
            flagDown=true;
        }
    }
}
