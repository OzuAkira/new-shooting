using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_death : MonoBehaviour
{
    GameObject GM;
    public int HP = 1;
    public bool hpStoper = false;
    private void Awake()
    {
        GM = GameObject.Find("GameMaster");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("player_bullet"))//player�̒e�ɓ���������
        {
            //�X�R�A�𑝉�������B��ŕ`��
            //���̃^�C�~���O�ŉ����Đ�����̂��A��
            HP--;
            Destroy(collision.gameObject);
            if(hpStoper)HP = 1;
            if(HP <= 0)Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            Debug.Log("miss!");
            Resurrection resu = GM.GetComponent<Resurrection>();
            if (resu.isResurrection == false)collision.gameObject.SetActive(false);
        }
    }
}
