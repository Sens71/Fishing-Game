using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Vector3 scale;
    public float jumpForce;
    public KeyCode jumpButton;
    
    void Start()
    {
        
        scale = transform.localScale;
    }

    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        FlipX(horizontal);
        rb.MovePosition(transform.position+Vector3.right * speed * horizontal * Time.fixedDeltaTime);
        Jump();
    }
  
    private void FlipX(float horizontal)
    {   
        if(horizontal == 0)
        {
            return;
        }
        if(horizontal < 0)
        {
            transform.localScale = new Vector3(-scale.x,scale.y,scale.z);
        }
        if(horizontal > 0)
        {
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(Vector2.up * jumpForce);
        } 
    }
}
