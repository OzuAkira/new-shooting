using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player_bullet"))//player‚Ì’e‚É“–‚½‚Á‚½‚ç
        {
            Destroy(gameObject);
        }
    }
}
