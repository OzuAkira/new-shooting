using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class waveBullet : MonoBehaviour
{

    float i = 0 , add_i = 0.01f , moveSpeed = 0.03f , y_moveSpeed = 0.02f;
    Rigidbody2D rb;
    [SerializeField] bool isMinus = false;
    float old_y = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(move());
    }

    public GameObject _childBullet;
    IEnumerator move()
    {
        while (true)
        {
            if (isMinus)
            {
                float my_x_Pos = math.sin(i) * moveSpeed, my_y_Pos = math.cos(i) * y_moveSpeed;
                i += add_i;
                //座標で計算する
                if (old_y > gameObject.transform.position.y) break;
                old_y = gameObject.transform.position.y;

                float angle = math.sin(i) * 100;
                transform.rotation = Quaternion.Euler(0, 0, angle);
                rb.MovePosition(gameObject.transform.position + new Vector3(-my_x_Pos, my_y_Pos, 0));
            }
            else 
            {
                float my_x_Pos = math.sin(i)*moveSpeed , my_y_Pos = math.cos(i) * y_moveSpeed;
                i += add_i;
                //座標で計算する
                if (old_y > gameObject.transform.position.y) break;

                old_y = gameObject.transform.position.y;

                float angle = math.sin(i) * -100;
                transform.rotation = Quaternion.Euler(0,0,angle);
                rb.MovePosition(gameObject.transform.position + new Vector3(my_x_Pos, my_y_Pos,0));
            }
            yield return null;
        }
        
        yield return null;

        Quaternion myRotation = gameObject.transform.rotation;
        int shot_half_num = 3;
        while (true)
        {
            for (int i = 1; i <= shot_half_num; i++)
            {
                //Eulerと純粋なQuatarnionのコンフリクト

                Instantiate(_childBullet, gameObject.transform.position, Quaternion.Euler(0,0,myRotation.z));
              //  Instantiate(_childBullet, gameObject.transform.position, Quaternion.Euler(0, 0, gameObject.transform.rotation.z + i*5));
              //  Instantiate(_childBullet, gameObject.transform.position, Quaternion.Euler(0, 0, gameObject.transform.rotation.z - i * 5));
            }
            yield return new WaitForSeconds(1);


        }
    }
}
