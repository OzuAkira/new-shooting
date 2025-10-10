using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class gravity_bullet : MonoBehaviour
{
    Rigidbody2D rb;
    float g;
    Vector3 movePos;
    float rand_range = 1f;
    void Start()
    {
        movePos = new Vector3( transform.position.x , transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.25f;
        float r = UnityEngine.Random.Range(-rand_range, rand_range);

        rb.AddForce(new Vector2(r, 5+r/2), ForceMode2D.Impulse);
    }
            
}
