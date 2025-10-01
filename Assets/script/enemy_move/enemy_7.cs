using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class enemy_7 : MonoBehaviour
{
    [SerializeField] GameObject straght_bullet;
    int loop_int = 45 ;
    [SerializeField] float stopPos = 3 , moveSpeed = -0.1f , moveSpeed_2 = 0.01f , i = 0;
    Rigidbody2D rb;

    float myXpos = 0;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(firstMove());
    }
    IEnumerator firstMove()
    {
        while (gameObject.transform.position.y > stopPos)
        {
            gameObject.transform.position += new Vector3(0 , moveSpeed , 0);
            yield return null;
        }

        circl_bulled();

        Vector3 movePos;
        int frameCount = 0;
        while (true)
        {
            myXpos = math.sin(i);
            i+= moveSpeed_2;

            frameCount++;

            movePos = new Vector3(2 * myXpos,gameObject.transform.position.y,0);
            rb.MovePosition(movePos);
            yield return null;
            if (frameCount % 120 == 0) circl_bulled();
        }
    }
    void circl_bulled()
    {
        for (int i = 0; i < loop_int; i++)
        {
            Instantiate(straght_bullet,gameObject.transform.position , Quaternion.Euler(0,0,i*8));
        }
    }


}
