using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body_bom : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy_bullet"))Destroy(collision.gameObject);
    }
}
