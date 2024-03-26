using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private bool facingRight;
    private Vector3 direction;
    private Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    void FixedUpdate()
    {
        if (facingRight)
        {
            direction = Vector3.right;
            
        }
        else
        {
            direction = Vector3.left;
        }
        rb.MovePosition(transform.position + direction * Time.fixedDeltaTime * speed);
    }
}
