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
    BoxCollider2D boxCollider;
    

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
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb.AddForce(new Vector2(moveHorizontal * speed, 0), ForceMode2D.Impulse);
        }
        
        
        if (!isJumping && moveVertical > 0.1f)
        {
            Debug.Log("Jump value is " + moveVertical);
            Debug.Log("isJumping: " + isJumping);

            rb.AddForce(new Vector2(0, moveVertical * jumpforce), ForceMode2D.Impulse);
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
