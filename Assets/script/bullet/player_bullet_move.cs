using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_bullet_move : MonoBehaviour
{
    [SerializeField]float moveSpeed = 0.1f;
    [SerializeField] int destroy_Fram = 6;
    
    CapsuleCollider2D cc;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (transform.position.y > destroy_Fram) Destroy(gameObject);
        Vector3 movepos;
        movepos = transform.position + transform.rotation * (Vector3.up * moveSpeed);
        rb.MovePosition(movepos);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wall"))
        {
            cc.enabled = false;
        }
    }
}
