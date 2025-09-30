using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class enemy_2 : MonoBehaviour
{
    //move()�ȊO�Aenemy_1�ƑS������

    Vector3 velocity = new Vector3(-0.02f, 0.001f, 0), myPos;
    Rigidbody2D rb;
    public int move_i = 0, destroy_frame = 500;

    [SerializeField] GameObject eim_Bullet;
    int interval = 60, shot_i = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myPos = gameObject.transform.position;

        Instantiate(eim_Bullet, gameObject.transform.position, Quaternion.identity);//�o�������u�Ԃɒe�𔭎�
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

        if (move_i > destroy_frame) Destroy(gameObject);//destroy_frame�o������I�u�W�F�N�g������
    }
    void shot()
    {

        if (shot_i % interval == 0)//interval�t���[���Ɉ��e�𔭎�
        {
            shot_i = 0;
            Thread.Sleep(Random.Range(0, 10));
            Instantiate(eim_Bullet, gameObject.transform.position, Quaternion.identity);
        }
        shot_i++;
    }
}
