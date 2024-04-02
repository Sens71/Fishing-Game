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

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag == "Retrieve")
        {
            Catch();
        }
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Hook>(out var hook))
        {
            if (hook.state == HookStates.Catch ||hook.state == HookStates.Retrieve)
            {
                speed = 0;
                //transform.position = hook.transform.position;
            }

        }
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
    private void Catch()
    {
        Destroy(gameObject);
    }
}
