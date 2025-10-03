using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    
    [Header("Player values")]
    public Rigidbody2D rb;
    [SerializeField] BoxCollider2D playerBoxCollider;
    [SerializeField] public Animator animator;
    [SerializeField] public SpriteRenderer playerRenderer;
    [SerializeField] AudioSource AudioSource;
    // should be in a separate script 
    int ShiningCount = 0;


    [Header("Movement")]
    public float moveHorizontal;
    public float moveVertical;
    public float speed;
    Vector2 movementInput;

    // boards to bits better jumping 
    [Header("Jumping")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool isHoldingJump;
    // GameJam Code
    public bool isJumping;
    [SerializeField] public float jumpforce;


   
    // damage logic, should probably be moved to another script 
    [SerializeField] Vector2 hurtFling = new Vector2(4f, 4f);



    private void OnEnable()
    {
        Health.onTakeDamage += Health_onTakeDamage;
    }


    private void OnDisable()
    {
        Health.onTakeDamage -= Health_onTakeDamage;
    }
    private void Health_onTakeDamage()
    {
        if (rb.linearVelocityX >= 0f)
        {
            animator.SetBool("isHurt", true);
            rb.linearVelocity =  rb.linearVelocity * hurtFling;
            rb.linearVelocityY = 0f;
        }
        else
        {
            rb.linearVelocity = rb.linearVelocity * hurtFling * -1f;
            rb.linearVelocityY = 0f;// should always be positive
            animator.SetBool("isHurt", true);
        }
    }
    void Start()
    {   
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        playerRenderer = gameObject.GetComponent<SpriteRenderer>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        //grab the animator 
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("AttackA"))
        {
            Debug.Log("animation has ended");
            animator.SetBool("isAttacking", false);

        }
    }


    private void FixedUpdate()
    {
        Debug.Log("Jump value is " + moveVertical);
        Debug.Log("isJumping: " + isJumping);
        animator.SetBool("isHurt", false);
        Vector2 playerVelocity = new Vector2(movementInput.x * speed, rb.linearVelocityY);
        rb.linearVelocity = playerVelocity;
        if (rb.linearVelocityX == 0f)
        {
            animator.SetBool("isRunning", false);
            
        }
        if (rb.linearVelocityX > 0f)
        {
          //  Debug.Log("current velocity is " + rb.linearVelocity);
            //facing right
            animator.SetBool("isRunning", true);
            playerRenderer.flipX = false;

        }
        else if (rb.linearVelocityX < 0f)
        {
            // facing left
         //   Debug.Log("current velocity is " + rb.linearVelocity);

            animator.SetBool("isRunning", true);
            playerRenderer.flipX = true;
        }
        /*       if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
               {
                   rb.AddForce(new Vector2(moveHorizontal * speed, 0), ForceMode2D.Impulse);
               }*/

        // Jump logic
        if (isJumping == true)
        {
            //playerBody.velocity += new Vector2(0f, jumpSpeed);

            rb.AddForce(new Vector2(0f, (Physics2D.gravity.y * (jumpforce - 1)) * -1f), ForceMode2D.Impulse);
            isJumping = false;
            animator.SetBool("isJumping", true);
            AudioSource.Play();
        }

        // falling logic
        if ( rb.linearVelocityY < 0f)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }

        // landing logic 
        if (hasLanded())
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }


    }

    private bool hasLanded()
    {
        return rb.linearVelocityY < 0f && playerBoxCollider.IsTouchingLayers(LayerMask.GetMask("Platforms"));
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
            if (value.started) { isJumping = true; 
                isHoldingJump = false; 
            }
            else if (value.started && value.duration > 0.3f)
            {
                isJumping = true;
                isHoldingJump = false;
            }
        }
       
                    
    }


    public int GetShiningCount() => ShiningCount;

    public void SetShiningCount(int shiningCount)
    {
        ShiningCount += shiningCount;
    }

    public void OnAttackA(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            animator.SetBool("isAttacking", true);
        }
    }
}
