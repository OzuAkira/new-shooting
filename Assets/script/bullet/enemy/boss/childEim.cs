using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childEim : MonoBehaviour
{
    public bool finish = false;
    public GameObject player;
    [SerializeField] float addRotation , moveSpeed = 0.01f;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
        StartCoroutine(move());
    }
    IEnumerator move()
    {
        Vector3 vect = transform.position - player.transform.position;
        float angle = Mathf.Atan2(vect.y, vect.x) * Mathf.Rad2Deg;//ベクトルをもとにRotationに入れる数値を計算
        transform.rotation = Quaternion.Euler(0, 0, angle + addRotation);

        while (true)
        {
            if (finish)
            {
                Vector3 movepos;
                if (player.activeSelf == false)
                {
                    movepos = Vector3.down * moveSpeed;
                }
                movepos = transform.position + transform.rotation * (Vector3.down * moveSpeed);//弾の向きに直進
                rb.MovePosition(movepos);
            }
            yield return null;
        }
    }
}
