using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject GameManager;

    public GameObject player;
    public Rigidbody2D rb;
    public float moveInput;
    public float movementSpeed;
    public float jumpForce = 15f;
    
    public bool canJump;


    public bool testing;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (testing == true) {
            if (Input.GetKeyDown(KeyCode.D)) {
                Debug.Log(moveInput);
            }

        }
        if (Input.GetKey(KeyCode.Space) && canJump && GameManager.GetComponent<GameManager>().gameOver == false) {
            rb.velocity = transform.up * jumpForce;
        }

        if (rb.position.y <= -3.808498f)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        rb.velocity = new Vector2 (moveInput * movementSpeed, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D col2D)
    {
        if (col2D.gameObject.tag == "Ground") {
            canJump = true;
        }
        if (col2D.gameObject.tag == "Death")
        {
            GameManager.GetComponent<GameManager>().gameOver = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("Dead");
        }
    }

}
