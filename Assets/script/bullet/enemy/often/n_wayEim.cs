using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n_wayEim : MonoBehaviour
{
    GameObject playerObj;

    float addRotation = 90 , var_angle = 0;
    [SerializeField] int loop_i = 2;//�y�d�v�z�o�����������e�̐�//2 - 1 �̒l������
    //�i��j5way�̏ꍇ�A5//2 = 2(�����_�ȉ��؂�̂ď��Z) + 1(���̃X�N���v�g�����Ă�I�u�W�F�N�g���e�ɂȂ邩��)

    [SerializeField] GameObject straght_bullet;

    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 0.1f , max_angle = 15;

    private void Start()
    {
        playerObj = GameObject.Find("player");
        rb = GetComponent<Rigidbody2D>();

        Vector3 velocity = playerObj.transform.position - gameObject.transform.position;//���@�Ƃ̃x�N�g�����v�Z
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;//�x�N�g�������Ƃ�Rotation�ɓ���鐔�l���v�Z
        Quaternion bullet_q = Quaternion.Euler(0, 0, angle + addRotation);//�ϐ��ɂ���K�v���́A���܂�Ȃ�

        transform.rotation = Quaternion.Euler(0, 0, angle + addRotation);//���̃I�u�W�F�N�g�����@�_��������ARotation��ύX


        for (int i = 0; i < loop_i; i++)
        {
            var_angle = max_angle / (i + 1);
            Instantiate(straght_bullet , gameObject.transform.position , Quaternion.Euler(0, 0, (angle + addRotation) + var_angle));
            Instantiate(straght_bullet, gameObject.transform.position, Quaternion.Euler(0, 0, (angle + addRotation) + var_angle * -1));//�����Ŋp�x��-1����Z���邱�ƂŁA�v�Z�ʂ𔼌�
        }
    }
    void Update()
    {
        Vector3 movepos;
        if (playerObj.activeSelf == false)
        {
            movepos = Vector3.down * moveSpeed;
        }
        movepos = transform.position + transform.rotation * (Vector3.down * moveSpeed);//�e�̌����ɒ��i & Straght_move��Vector3.down�Ői��ł������獇�킹��
        rb.MovePosition(movepos);


    }
}
