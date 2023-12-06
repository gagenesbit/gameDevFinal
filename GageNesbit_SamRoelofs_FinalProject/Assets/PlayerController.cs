using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    public float moveSpeed = 5f;
    public float sensitivity = 2f; 
    public float jumpForce = 5f;
    float verticalRotation = 0f;
    int jumpFrames=0;
    private Rigidbody rb;
    public bool puzzleActive;

    //Main Message text
    public GameObject interactionText;

    //color puzzle fields
    public string barrel;
    //Deck puzzle fields;
    public bool hasBlackPowder=false;
    public bool hasfuse=false;

    //Opening the door
    public bool purpleKey,orangeKey, yellowKey;
    //Inventory
    public GameObject purplePic,orangePic,yellowPic;

    public int codeReset=0;


    void Start(){
        rb = GetComponent<Rigidbody>();
        puzzleActive=false;
        interactionText.SetActive(false);
    }

    void Update()
    {
        if (!puzzleActive){
            move();
        }
        inventory();

        
        
    }

    private void move(){
        jumpFrames++;
        // Get input values
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Move the player
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);


        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the player horizontally (yaw)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically (pitch)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);


        if (Input.GetButtonDown("Jump") && jumpFrames>48)
        {
            jumpFrames=0;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


    }
    void OnCollisionEnter(Collision collision)
    {
         if(collision.gameObject.CompareTag("redBarrel")){
            barrel="red";
        }
        else if(collision.gameObject.CompareTag("whiteBarrel")){
            barrel="white";
        }
        else if(collision.gameObject.CompareTag("greenBarrel")){
            barrel="green";
        }
        else if(collision.gameObject.CompareTag("purpleKey")){
            purpleKey=true;
        }
        else if(collision.gameObject.CompareTag("orangeKey")){
            orangeKey=true;
        }
        else if(collision.gameObject.CompareTag("yellowKey")){
            yellowKey=true;
        }
    }

    private void inventory(){
        if(purpleKey){
            purplePic.SetActive(true);
        }
        else{
            purplePic.SetActive(false);
        }

        if(orangeKey){
            orangePic.SetActive(true);
        }
        else{
            orangePic.SetActive(false);
        }
        

        if(purpleKey){
            purplePic.SetActive(true);
        }
        else{
            purplePic.SetActive(false);
        }


        if(yellowKey){
            yellowPic.SetActive(true);
        }
        else{
            yellowPic.SetActive(false);
        }
    }
}
