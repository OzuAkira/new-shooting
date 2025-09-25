using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_bullet_move : MonoBehaviour
{
    [SerializeField]float moveSpeed = 100f;
    [SerializeField] int destroy_Fram = 60;
    int i;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (i >= destroy_Fram)Destroy(gameObject);
        else
        {
            i++;
            rb.velocity = new Vector2(0, moveSpeed);//ê^è„Ç…êiÇﬁ
        }

            
    }
}
