using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class waveBullet : MonoBehaviour
{

    float i = 0 , add_i = 0.01f , moveSpeed = 0.02f;
    Rigidbody2D rb;
    [SerializeField] bool isMinus = false;
    float old_i = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(move());
    }
    IEnumerator move()
    {
        while (true)
        {
            if (isMinus)
            {

            }
            else 
            {
                float my_x_Pos = math.sin(i)*moveSpeed , my_y_Pos = math.cos(i) * moveSpeed;
                i += add_i;
                //ベクトルではなく座標で計算するべき
                if (old_i > my_y_Pos) break;
                Debug.Log("old= " + old_i + " y= " + my_y_Pos);
                old_i = my_y_Pos;

                
                rb.MovePosition(gameObject.transform.position + new Vector3(my_x_Pos, my_y_Pos,0));
            }
            yield return null;
        }
        
        yield return null;


    }
}
