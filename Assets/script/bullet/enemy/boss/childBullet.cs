using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childBullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 0.1f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(move());
    }


    IEnumerator move()
    {
        while (true)
        {
            Vector2 movePos = transform.position + transform.rotation * (Vector3.down * moveSpeed);
            rb.MovePosition(movePos);

            yield return null;
        }
    }
}
