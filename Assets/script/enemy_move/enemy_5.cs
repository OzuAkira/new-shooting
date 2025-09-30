using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class enemy_5 : MonoBehaviour
{
    [SerializeField] Vector3 velocity = new Vector3(-0.02f, 0.001f, 0), myPos;
    Rigidbody2D rb;
    public int move_i = 0, destroy_frame = 500;

    [SerializeField] GameObject eim_Bullet;
    int interval = 60, shot_i = 0;

    GameObject playerObj;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myPos = gameObject.transform.position;

        interval = Random.Range(0, 120);

        Instantiate(eim_Bullet, gameObject.transform.position, Quaternion.identity);//出現した瞬間に弾を発射
    }
    private void Update()
    {
        move();
        shot();
    }
    private void move()
    {
        myPos += velocity;
        rb.MovePosition(myPos);
        move_i++;

        if (move_i > destroy_frame) Destroy(gameObject);//destroy_frame経ったらオブジェクトを消す
    }
    void shot()
    {
        //一旦保留

        /*
        int loop_i = 5;
        Vector3 velocity = playerObj.transform.position - gameObject.transform.position;//自機とのベクトルを計算
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;//ベクトルをもとにRotationに入れる数値を計算
        Quaternion bullet_q = Quaternion.Euler(0, 0, angle + addRotation);
        */

        if (shot_i % interval == 0)//interval(random)フレームに一回弾を発射
        {
            shot_i = 0;
            /*
            for(int i = 0; i < loop_i; i++)
            {
                Instantiate(eim_Bullet, gameObject.transform.position, Quaternion.identity);
            }
            */
            
        }
        shot_i++;
    }
}
