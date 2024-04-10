using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hook : MonoBehaviour
{
    public float sideSpeed;
    public float retrieveSpeed;
    public float pullSpeed;
    public float throwForce;
    [Header("Controll")]
    public Transform retrievePoint;
    [Header("UI")]
    public GameObject ResultPanel;
    public TMP_Text moneyPro;

    private Camera mainCamera;
    private Rigidbody2D rb;
    private Vector3 targetPosition;

    public HookStates state = HookStates.Idle;
    public event Action OnRetrieve;

    private List<Fish> fishCought = new List<Fish>();
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
            OnRetrieve?.Invoke();
            state = HookStates.Idle;
            var result = 0;
            foreach(var fish in fishCought)
            {
                result += fish.money;
            }
            fishCought.Clear();
            moneyPro.text = $"You Got {result} dollars";

            ResultPanel.SetActive(true);
        }
    }
    public void AddFish(Fish fish)
    {
        fishCought.Add(fish);
    }
}
