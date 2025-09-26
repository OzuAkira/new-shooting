using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleEim : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    Rigidbody2D rb;
    [SerializeField]GameObject playerObj;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObj = GameObject.Find("player");
        Vector3 velocity = playerObj.transform.position - gameObject.transform.position;//���@�Ƃ̃x�N�g�����v�Z
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;//�x�N�g�������Ƃ�
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void Update()
    {
        var movepos = transform.position + transform.rotation * (Vector3.right * moveSpeed);//�e�̌����ɒ��i
        rb.MovePosition(movepos);
    }
}
