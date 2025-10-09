using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eim_Scatter : MonoBehaviour
{
    public float moveSpeed = 0.6f;
    public float addRotation = 270;

    Rigidbody2D rb;
    GameObject playerObj;
    System.Random rand = new System.Random();
    Vector2 oldPos;

    public GameObject child;
    int Angle_Range = 30, scatter_count = 30;
    int speed_range = 5;
    //��{�I�ɂ�SimpleEim�Ɠ���
    //�������A�������ǉ�����Ă���
    private void Start()
    {
        oldPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        playerObj = GameObject.Find("player");
        Vector3 velocity = playerObj.transform.position - gameObject.transform.position;//���@�Ƃ̃x�N�g�����v�Z
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;//�x�N�g�������Ƃ�Rotation�ɓ���鐔�l���v�Z
        transform.rotation = Quaternion.Euler(0, 0, angle + addRotation);

        StartCoroutine(child_shot());
        
    }
    private void Update()
    {
        Vector3 movepos;
        if (playerObj.activeSelf == false)
        {
            movepos = Vector3.down * moveSpeed;
        }
        movepos = transform.position + transform.rotation * (Vector3.up * moveSpeed);//�e�̌����ɒ��i
        rb.MovePosition(movepos);
    }
    IEnumerator child_shot()
    {
        yield return null;

        for (int i = 0; i < scatter_count; i++)
        {
            float child_angle = rand.Next(-Angle_Range, Angle_Range);

            //�} Angle_Range �͈̔͂Ń����_���Ȋp�x�ɐ���
            Straight_move child_Scatter = Instantiate(child, oldPos, Quaternion.Euler(0, 0,
                transform.rotation.eulerAngles.z + child_angle + 180)).GetComponent<Straight_move>();//180�����Ċp�x�𔽓]

            float child_speed = rand.Next(speed_range, speed_range * 3) * 0.01f;//Random.Next()�̈�����int�^����Ȃ��Ƃ����Ȃ��̂ŁA0.01�������Ă���
            child_Scatter.moveSpeed = child_speed;
        }


    }
}
