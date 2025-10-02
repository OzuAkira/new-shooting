using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n_wayEim : MonoBehaviour
{
    GameObject playerObj;

    float addRotation = 90 , var_angle = 0;
    [SerializeField] int loop_i = 2;//【重要】出現させたい弾の数//2 - 1 の値が入る
    //（例）5wayの場合、5//2 = 2(小数点以下切り捨て除算) + 1(このスクリプトがついてるオブジェクトも弾になるから)

    [SerializeField] GameObject straght_bullet;

    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 0.1f , max_angle = 15;

    private void Start()
    {
        playerObj = GameObject.Find("player");
        rb = GetComponent<Rigidbody2D>();

        Vector3 velocity = playerObj.transform.position - gameObject.transform.position;//自機とのベクトルを計算
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;//ベクトルをもとにRotationに入れる数値を計算
        Quaternion bullet_q = Quaternion.Euler(0, 0, angle + addRotation);//変数にする必要性は、あまりない

        transform.rotation = Quaternion.Euler(0, 0, angle + addRotation);//このオブジェクトが自機狙いだから、Rotationを変更


        for (int i = 0; i < loop_i; i++)
        {
            var_angle = max_angle / (i + 1);
            Instantiate(straght_bullet , gameObject.transform.position , Quaternion.Euler(0, 0, (angle + addRotation) + var_angle));
            Instantiate(straght_bullet, gameObject.transform.position, Quaternion.Euler(0, 0, (angle + addRotation) + var_angle * -1));//ここで角度に-1を乗算することで、計算量を半減
        }
    }
    void Update()
    {
        Vector3 movepos;
        if (playerObj.activeSelf == false)
        {
            movepos = Vector3.down * moveSpeed;
        }
        movepos = transform.position + transform.rotation * (Vector3.down * moveSpeed);//弾の向きに直進 & Straght_moveがVector3.downで進んでいたから合わせる
        rb.MovePosition(movepos);


    }
}
