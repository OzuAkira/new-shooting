using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight_move : MonoBehaviour
{
    Rigidbody2D rb;
    
    public float moveSpeed = 0.1f;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector3 movepos;
        movepos = transform.position + transform.rotation * (Vector3.down * moveSpeed);
        rb.MovePosition(movepos);
    }
}
