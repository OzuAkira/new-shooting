using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public int have_power = 1 , have_point = 10;
    [SerializeField] float y_force = 2 , destroy_y = -7;
    public bool isPoint = false;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(0,y_force), ForceMode2D.Impulse);
    }
    private void Update()
    {
        if (transform.position.y < destroy_y) Destroy(gameObject);
    }
}
