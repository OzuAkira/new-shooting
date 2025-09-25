using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_a_bullet : MonoBehaviour
{
    //���̃X�N���v�g�ŕ`�����Ɓ�

    //�v���C���[�ɒe�������������̏���
    //�e�̋N��

    //interval�͕`���Ȃ��I

    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] int destroy_Frame;
    int i;
    bool wall_flag;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (wall_flag)
        {
            i++;
            if (destroy_Frame <= i)Destroy(gameObject);//�ǂ�destroy_flam�ԐG��Ă��������
        }
        rb.velocity = new Vector2(0, moveSpeed);//�^���ɓ����� 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.SetActive(false);
            Debug.Log("miss!!");
        }
        else if (collision.CompareTag("wall"))
        {
            wall_flag = true;
        }
    }
}
