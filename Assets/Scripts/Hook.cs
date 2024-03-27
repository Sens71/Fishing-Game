using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D rb;
    private Vector3 targetPosition;
    public HookStates state = HookStates.Idle;

    public Transform retrievePoint;

    public float sideSpeed;
    public float retrieveSpeed;
    public float pullSpeed;
    public float throwForce;
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        switch (state)
        {
            case HookStates.Idle:
                WaitForThrow();
                break;
            case HookStates.Retrieve:
                Retrieve();
                break;
            case HookStates.Catch:
                PullHook();
                break;
            case HookStates.Throw:
                ThrowHook();
                break;
        }
    }
    private void WaitForThrow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector2.down * throwForce);
            state = HookStates.Throw;
        }
    }
    private void ThrowHook()
    {
        if(rb.velocity.sqrMagnitude < 0.3f)
        {
            state = HookStates.Catch;
        }
    }
    private void PullHook()
    {
        var direction = Vector3.zero;
        if (Input.GetMouseButton(0))
        {
            Vector3 mousepos = Input.mousePosition;
            mousepos.z = mainCamera.transform.position.z;
            targetPosition = mainCamera.ScreenToWorldPoint(mousepos);
            direction = targetPosition - transform.position;
            direction.y = 0f;
        }
        rb.MovePosition(transform.position +(direction * sideSpeed + Vector3.up * pullSpeed) * Time.fixedDeltaTime);
        if(transform.position.y > 0f)
        {
            state = HookStates.Retrieve;
        }
    }
    private void Retrieve()
    {
        Vector2 direction = (retrievePoint.position - transform.position).normalized;
        float distance = Vector2.Distance(rb.position,retrievePoint.position);
        if(distance > 0.3f)
        {
            Vector2 velocity = direction * retrieveSpeed;
            rb.velocity = velocity;
        }
        else
        {
            rb.velocity = Vector2.zero;
            state = HookStates.Idle;
        }
    }
}
