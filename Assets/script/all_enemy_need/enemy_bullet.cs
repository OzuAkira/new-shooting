using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{
    //���̃X�N���v�g�́A�����蔻����������Ă���
    [SerializeField] int destroy_Frame = 600;
    GameObject GM;
    int i;
    bool wall_flag;

    private void Awake()
    {
        GM = GameObject.Find("GameMaster");
    }
    void Update()
    {
        if (wall_flag)
        {
            i++;
            if (destroy_Frame <= i)Destroy(gameObject);//�ǂ�destroy_flam�ԐG��Ă��������
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            Resurrection resu = GM.GetComponent<Resurrection>();

            if (resu.isResurrection == false)//���G���ԂłȂ���Δ�e����
            {
                player.SetActive(false);
                Debug.Log("miss!!");
            }
        }
        else if (collision.CompareTag("wall"))
        {
            wall_flag = true;
        }
    }
}
