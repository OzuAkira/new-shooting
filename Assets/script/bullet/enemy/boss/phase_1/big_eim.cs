using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class big_eim : MonoBehaviour
{
    public GameObject playerObj , child_EimObj;
    public bool minus = false;

    Rigidbody2D rb;
    Vector2 move_vector;
    public Vector3 goale_1 = new Vector3(3,-0.5f,0), goale_2 = new Vector3(-3,-0.5f, 0);
    float moveSpeed = 0.01f , addRotation = -90;
    void Start()
    {
        playerObj = GameObject.Find("player");
        move_vector = transform.position - playerObj.transform.position;
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(move());
    }
    Vector3 startPos = new Vector3(0,3);
    IEnumerator move()
    {
        bool isIns = false , isIns_2 = false;
        List<childEim> childEims = new List<childEim>();

        if (minus)
        {
            while (gameObject.transform.position != startPos + goale_2)
            {
                move_vector = transform.position + goale_2 * moveSpeed;

                if (gameObject.transform.position.x < goale_2.x) transform.position = startPos + goale_2;
                else if (isIns== false && gameObject.transform.position.x < goale_2.x / 3)
                {
                    isIns = true;
                    childEims.Add( Instantiate(child_EimObj, gameObject.transform.position, Quaternion.identity).GetComponent<childEim>());
                }

                else if (isIns_2 == false && gameObject.transform.position.x < (goale_2.x / 3)*2)
                {
                    isIns_2 = true;
                    childEims.Add(Instantiate(child_EimObj, gameObject.transform.position, Quaternion.identity).GetComponent<childEim>());
                }

                rb.MovePosition(move_vector);
                yield return null;
            }
        }
        else
        {
            while (gameObject.transform.position != startPos + goale_1)
            {
                move_vector = transform.position + goale_1 * moveSpeed;

                if (gameObject.transform.position.x > goale_1.x) transform.position = startPos + goale_1;
                else if (isIns == false && gameObject.transform.position.x > goale_1.x / 3)
                {
                    isIns = true;
                    childEims.Add(Instantiate(child_EimObj, gameObject.transform.position, Quaternion.identity).GetComponent<childEim>());
                }

                else if (isIns_2 == false && gameObject.transform.position.x > (goale_1.x / 3)*2)
                {
                    isIns_2 = true;
                    childEims.Add(Instantiate(child_EimObj, gameObject.transform.position, Quaternion.identity).GetComponent<childEim>());
                }

                rb.MovePosition(move_vector);
                yield return null;
            }
        }

        foreach (var child in childEims)
        {
            child.finish = true;
        }

        yield return StartCoroutine(wait());


        Vector3 vect = transform.position - playerObj.transform.position;
        float angle = Mathf.Atan2(vect.y, vect.x) * Mathf.Rad2Deg;//ベクトルをもとにRotationに入れる数値を計算

        transform.rotation = Quaternion.Euler(0, 0, angle + addRotation);


        float moveSpeed_2 = 0.05f , count_i = 0 , add_i = 0.01f;//このMoveSpeedをSinを使って加速させようとおもてる。
                                  //ChildEimのMoveSpeedの変数をここと紐づけたい
        
        while (true)
        {
            if (math.sin(count_i) < 0)
            {
                moveSpeed_2 = math.sin(count_i) * 0.05f;
                count_i += add_i;
            }
            else moveSpeed_2 = 0.05f;

            

            Vector3 movepos;
                if (playerObj.activeSelf == false)
                {
                    movepos = Vector3.down * moveSpeed_2;
                }
                movepos = transform.position + transform.rotation * (Vector3.down * moveSpeed_2);//弾の向きに直進
                rb.MovePosition(movepos);
            
            yield return null;
        }


    }
    public IEnumerator wait()
    {
        float socond = 1.5f;
        yield return new WaitForSeconds(socond);
    }

}
