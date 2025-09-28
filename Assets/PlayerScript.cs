using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    [SerializeField] public float jumpforce;
    public bool isJumping;
    public float moveHorizontal;
    public float moveVertical;
    [SerializeField] BoxCollider2D playerBoxCollider;
    Vector2 movementInput; 
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        rb = gameObject.GetComponent<Rigidbody2D>();

        speed = 3f;
        jumpforce = 5f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }


    private void FixedUpdate()
    {   
        Debug.Log("Jump value is " + moveVertical);
        Debug.Log("isJumping: " + isJumping);

        Vector2 playerVelocity = new Vector2(movementInput.x * speed, rb.linearVelocityY);
        rb.linearVelocity = playerVelocity;
 /*       if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb.AddForce(new Vector2(moveHorizontal * speed, 0), ForceMode2D.Impulse);
        }*/

        // Jump logic
        if (isJumping == true)
        {
            //playerBody.velocity += new Vector2(0f, jumpSpeed);
            Debug.Log("attempted to jump");
            rb.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
            isJumping = false;
        }



    }

    public void OnMove(InputAction.CallbackContext value)
    {
        //if (!isAlive) { return; }
        movementInput = value.ReadValue<Vector2>();
    }


    public void OnJump(InputAction.CallbackContext value)
    {
        if (!playerBoxCollider.IsTouchingLayers(LayerMask.GetMask("Platforms"))) { return; }

        else
        {
            if (value.started) { isJumping = true; }
        }

    }


   /* void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collison)
    {
        if (collison.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }*/
}
