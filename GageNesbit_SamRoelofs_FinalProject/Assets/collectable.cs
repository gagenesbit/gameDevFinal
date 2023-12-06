using UnityEngine;
using TMPro;

public class CollectibleObject : MonoBehaviour
{
    public GameObject interactionText;
    public TextMeshProUGUI messageText;


    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, 180.0f * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            gameObject.SetActive(false);
            interactionText.SetActive(false);

        }
    }
}
