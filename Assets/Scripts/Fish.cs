using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private bool facingRight;
    private Vector3 direction;
    private Rigidbody2D rb;
    public float speed;
    private Hook _hook = null;
    public int money;
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
        if (collision.TryGetComponent<Hook>(out var hook))
        {
            if(hook.state == HookStates.Catch)
            {
                rb.isKinematic = true;
                speed = 0;
                _hook = hook;
                _hook.AddFish(this);
            }
        }
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    void FixedUpdate()
    {
        MoveAfterHook();
        MoveToSide();
    }
    private void Catch()
    {
        Destroy(gameObject);
    }
    private void MoveAfterHook()
    {
        if (_hook == null)
            return;
        transform.position = _hook.transform.position;
    }
    private void MoveToSide()
    {
        if (_hook != null)
            return;
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
