using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class enemy_4 : MonoBehaviour
{
    Vector3 myPos, movePos;
    float myY = 0, x_move_speed = 0.02f, y_move_speed = 0.1f, turnPos = 4;
    [SerializeField] int i = 0;

    Rigidbody2D rb;
    bool isTrun = false;
    int shot_i = 0 , interval = 120;

    public Sprite[] image;
    SpriteRenderer sr;

    [SerializeField] GameObject fiveWay_bullet;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        myPos = gameObject.transform.position;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        move();
        shot();
    }
    private void move()
    {

        myY = math.sin(i * y_move_speed);// + add_num);
        if (movePos.x > turnPos && isTrun == false) isTrun = true;
        else if (movePos.x < -turnPos && isTrun) isTrun = false;

        if (isTrun)
        {
            sr.sprite = image[0];
            i--;
        }
        else
        {
            sr.sprite = image[1];
            i++;
        }
        movePos = myPos + new Vector3(i * x_move_speed, myY, 0);

        rb.MovePosition(movePos);
    }

    void shot()
    {
        shot_i++;
        if (shot_i >= interval)
        {
            shot_i = 0;
            Instantiate(fiveWay_bullet, gameObject.transform.position, quaternion.identity);
        }
    }
}
