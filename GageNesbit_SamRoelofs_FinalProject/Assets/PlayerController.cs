using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sensitivity = 2f; 
    public float jumpForce = 5f;
    float verticalRotation = 0f;
    int jumpFrames=0;
    private Rigidbody rb;
    public bool puzzleActive;
    public GameObject interactionText;
    public int puzzleCode=0;
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
        // Check if the colliding object has a specific tag
        if (collision.gameObject.CompareTag("Brig"))
        {
            puzzleCode=1;
        }
    }
}
