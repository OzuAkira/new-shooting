using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class one_deray : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject playerObj;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(first());
    }
    float base_speed = 0.1f, i = 0 , add_i = 0.0001f;

    Vector3 movePos;
    IEnumerator first()
    {
        while (base_speed > 0)
        {
                base_speed -= i;
                i += add_i;
            
            movePos = transform.position + transform.rotation * (Vector3.down * base_speed);
            rb.MovePosition(movePos);

            yield return null;
        }
        yield return new WaitForSeconds(0.25f);

        StartCoroutine(eim());
    }

    IEnumerator eim()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObj = GameObject.Find("player");
        Vector3 velocity = playerObj.transform.position - gameObject.transform.position;//自機とのベクトルを計算
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;//ベクトルをもとにRotationに入れる数値を計算
        transform.rotation = Quaternion.Euler(0, 0, angle);

        float moveSpeed = 0, limit = 0.1f, add_speed = 0.01f;
        while (true)
        {
            if (moveSpeed < limit) moveSpeed += add_speed;
            else moveSpeed = limit;
                Vector3 movepos;
            if (playerObj.activeSelf == false)
            {
                movepos = Vector3.down * moveSpeed;
            }
            movepos = transform.position + transform.rotation * (Vector3.right * moveSpeed);//弾の向きに直進
            rb.MovePosition(movepos);
            yield return null;
        }
    }
}
