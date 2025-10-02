using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class enemy_1_2_5_6 : MonoBehaviour
{
    [SerializeField] Vector3 velocity = new Vector3(0.02f , 0.001f,0),myPos;
    Rigidbody2D rb;
    int move_i = 0, destroy_frame = 500;

    [SerializeField] GameObject eim_Bullet;
    public int interval = 90, shot_i =0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myPos = gameObject.transform.position;

        Instantiate(eim_Bullet, gameObject.transform.position, Quaternion.identity);
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

        if (move_i > destroy_frame) Destroy(gameObject);
    }
    void shot()
    {

        if (shot_i % interval == 0)
        {
            shot_i = 0;
            Thread.Sleep(Random.Range(0,10));
            Instantiate(eim_Bullet,gameObject.transform.position,Quaternion.identity);
        }
        shot_i++;
    }
}
