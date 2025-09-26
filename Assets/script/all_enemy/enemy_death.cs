using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_death : MonoBehaviour
{
    GameObject GM;
    private void Awake()
    {
        GM = GameObject.Find("GameMaster");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("player_bullet"))//player‚Ì’e‚É“–‚½‚Á‚½‚ç
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            Debug.Log("miss!");
            Resurrection resu = GM.GetComponent<Resurrection>();
            if (resu.isResurrection == false)collision.gameObject.SetActive(false);
        }
    }
}
