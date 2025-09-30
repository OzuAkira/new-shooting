using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{
    //このスクリプトは、当たり判定を実現している
    [SerializeField] int destroy_Frame = 600;
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
            if (destroy_Frame <= i)Destroy(gameObject);//壁にdestroy_flam間触れていたら消す
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            Resurrection resu = GM.GetComponent<Resurrection>();

            if (resu.isResurrection == false)//無敵時間でなければ被弾する
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
