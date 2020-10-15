using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movX, movY, jump, forceMultiplier, jumpMultiplayer;
    public Animator anim;
   
    private Vector2 ForceVector;
    
    private bool canJump = false;
    private Collider2D groundCollider;

    public bool jumpSelector;
    public Transform[] checkPoint;
    public LayerMask layers;
    public float[] checkRadius;
   
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        movY = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
        anim.SetFloat("Speed_X", Mathf.Abs(movX));


        if (movX > 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        
        if (groundCollider != null)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        

    }

    private void FixedUpdate()
    {

        ForceVector = new Vector2(movX, 0f) * forceMultiplier;

        rb.AddForce(ForceVector, ForceMode2D.Force);
       
        if (canJump && jump > 0)
        {
            rb.AddForce(Vector2.up * jumpMultiplayer, ForceMode2D.Impulse);
        }

        groundCollider = Physics2D.OverlapCircle((Vector2)checkPoint[0].position, checkRadius[0], layers);
        
    }
   
}
