using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] int destroy_Frame;
    GameObject GM;
    int i;
    bool wall_flag;

    private void Awake()
    {
        GM = GameObject.Find("GameMaster");
    }
    void Update()
    {
        if (wall_flag)
        {
            i++;
            if (destroy_Frame <= i)Destroy(gameObject);//•Ç‚Édestroy_flamŠÔG‚ê‚Ä‚¢‚½‚çÁ‚·
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            Resurrection resu = GM.GetComponent<Resurrection>();

            if (resu.isResurrection == false)
            {
                player.SetActive(false);
                Debug.Log("miss!!");
            }
        }
        else if (collision.CompareTag("wall"))
        {
            wall_flag = true;
        }
    }
}
