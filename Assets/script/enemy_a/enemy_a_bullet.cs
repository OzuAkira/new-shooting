using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_a_bullet : MonoBehaviour
{
    //このスクリプトで描くこと↓

    //プレイヤーに弾が当たった時の処理
    //弾の起動

    //intervalは描かない！

    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] int destroy_Frame;
    int i;
    bool wall_flag;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (wall_flag)
        {
            i++;
            if (destroy_Frame <= i)Destroy(gameObject);//壁にdestroy_flam間触れていたら消す
        }
        rb.velocity = new Vector2(0, moveSpeed);//真下に動かす 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.SetActive(false);
            Debug.Log("miss!!");
        }
        else if (collision.CompareTag("wall"))
        {
            wall_flag = true;
        }
    }
}
