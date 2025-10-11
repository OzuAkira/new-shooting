using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_death : MonoBehaviour
{
    GameObject GM , score , canvas;
    Text _text;
    public int HP = 1, hit_point = 1,kill_point = 10,now_score;
    public bool hpStoper = false , random_switch = false;
    public GameObject item_1,item_2;
    private void Awake()
    {
        canvas = GameObject.Find("Canvas_2");
        score = canvas.transform.Find("score").gameObject;
        

        GM = GameObject.Find("GameMaster");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("player_bullet"))//playerの弾に当たったら
        {
            //スコアを増加させる。
            _text = score.GetComponent<Text>();
            now_score = int.Parse(_text.text);

            now_score += hit_point;
            _text.text = now_score.ToString();


            HP--;
            Destroy(collision.gameObject);
            if (hpStoper) HP = 1;
            if (HP <= 0)
            {
                now_score += kill_point;
                _text.text = now_score.ToString();

                if (random_switch)
                {
                    if (UnityEngine.Random.Range(0f, 1f) > 0.5f) Instantiate(item_1, transform.position, Quaternion.identity);
                    else if (item_2 == null) Destroy(gameObject);
                    else Instantiate(item_2, transform.position, Quaternion.identity);
                }
                else Instantiate(item_1, transform.position, Quaternion.identity);
                //このタイミングで音を再生するのもアリ

                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("Player"))
        {
            player_bom player_b = collision.GetComponent<player_bom>();
            Resurrection resu = GM.GetComponent<Resurrection>();
            if (player_b.Invincible) return;
            if (resu.isResurrection == false) collision.gameObject.SetActive(false);
            
        }
    }
}
