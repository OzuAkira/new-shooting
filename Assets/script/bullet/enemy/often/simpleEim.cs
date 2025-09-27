using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleEim : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float addRotation = 270;

    Rigidbody2D rb;
    [SerializeField]GameObject playerObj;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObj = GameObject.Find("player");
        Vector3 velocity = playerObj.transform.position - gameObject.transform.position;//自機とのベクトルを計算
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;//ベクトルをもとにRotationに入れる数値を計算
        transform.rotation = Quaternion.Euler(0, 0, angle + addRotation);
    }
    private void Update()
    {
        var movepos = transform.position + transform.rotation * (Vector3.up * moveSpeed);//弾の向きに直進
        rb.MovePosition(movepos);
    }
}
