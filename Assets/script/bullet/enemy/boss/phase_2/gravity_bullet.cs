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
    void Start()
    {
        movePos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(up_move());
    }
    IEnumerator up_move()
    {
        float x = 0 , a = 0.01f;
        while (true)
        {
            Debug.Log(math.cos(x));
            x += a;
        }
    }
    IEnumerator down_move()
    {
        yield return null;
    }
            
}
