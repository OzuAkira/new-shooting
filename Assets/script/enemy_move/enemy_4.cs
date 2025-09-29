using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class enemy_4 : MonoBehaviour
{
    Vector3 myPos , movePos;
    float myY = 0 , x_move_speed = 0.005f , y_move_speed = 0.01f;
    [SerializeField] int i = 0 , add_num=180;

    Rigidbody2D rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        myPos = gameObject.transform.position;
    }
    private void Update()
    {
        myY = math.sin(i * y_move_speed + add_num);
        i++;

        movePos = myPos + new Vector3(i * x_move_speed , myY,0);

        rb.MovePosition(movePos);
    }
}
