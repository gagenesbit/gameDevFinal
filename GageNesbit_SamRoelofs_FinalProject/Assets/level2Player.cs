using UnityEngine;

public class level2Player : MonoBehaviour
{
    //Movement
    public float moveSpeed = 5f;
    public float sensitivity = 2f; 
    public float jumpForce = 5f;
    float verticalRotation = 0f;
    int jumpFrames=0;
    private Rigidbody rb;
    public bool puzzleActive;

    //puzzle objects
    public bool hasAxe=false;
    public bool axe;

    public GameObject axePic;
    public GameObject coconutPic;
    public GameObject oarPic;
    public GameObject woodPic;
    public GameObject sailPic;

    //raft part objects
    public bool hasWood=false;
    public bool hasSail=false;
    public bool hasOar=false;
    public bool hasCoconut=false;
    //character quests
    public bool raftComplete=false;

    public GameObject raft;


    void Start(){
        rb = GetComponent<Rigidbody>();
        puzzleActive=false;
    }

    void Update()
    {
        if (!puzzleActive){
            move();
        }

        inventory();

        if(raftComplete){
            raft.SetActive(true);
        }
        
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
   
    private void inventory(){
        if(hasAxe){
            axePic.SetActive(true);
        }
        else{
            axePic.SetActive(false);
        }

        if(hasCoconut){
            coconutPic.SetActive(true);
        }
        else{
            coconutPic.SetActive(false);
        }

        if(hasOar){
            oarPic.SetActive(true);
        }
        else{
            oarPic.SetActive(false);
        }

        if(hasSail){
            sailPic.SetActive(true);
        }
        else{
            sailPic.SetActive(false);
        }

        if(hasWood){
            woodPic.SetActive(true);
        }
        else{
            woodPic.SetActive(false);
        }
        

    }
}
