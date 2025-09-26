using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleEim : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        var velocity = transform.position + transform.rotation * (Vector3.up * moveSpeed);
        rb.MovePosition(velocity);
    }
}
