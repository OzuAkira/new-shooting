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
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        myPos = gameObject.transform.position;
    }
    private void Update()
    {
        move();
    }
    private void move()
    {

        myY = math.sin(i * y_move_speed);// + add_num);
        if (movePos.x > turnPos && isTrun == false) isTrun = true;
        else if (movePos.x < -turnPos && isTrun) isTrun = false;

        if (isTrun) i--;
        else i++;

        movePos = myPos + new Vector3(i * x_move_speed, myY, 0);

        rb.MovePosition(movePos);
    }

    void shot()
    {

    }
}
