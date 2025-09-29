using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class stage_1 : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image image;

    public GameObject enemy_1, enemy_2, enemy_3, enemy_4 , enemy_5;
    public Vector2 enemy1_2_pos, enemy3_pos, enemy4_pos;

    int count = 10;

    int next_count = 8;
    float wait_s = 0.5f;
    //�ʃX�N���v�g����R���[�`�����ĂԊ����ōs�����Ǝv�Ă�

    void Start()
    {
        StartCoroutine(game());
    }
    IEnumerator game()
    {
        yield return new WaitForSeconds(1);
        yield return gameStart();
        yield return new WaitForSeconds(2); 
        yield return StartCoroutine(phase_1());


    }
    IEnumerator gameStart()
    {
        UnityEngine.Color c = image.color;
        bool loop = false, isMax = false;
        float i = 0 , add_i = 0.01f;

        //�t�F�[�h�C�����t�F�[�h�A�E�g
        while (loop == false)
        {
            //Debug.Log("i= " + i);
            if (i < 1 && isMax == false) i += add_i;//Max�܂�0.01�Âグ��

            else if (isMax == false)//Max�܂ōs������A�P�b�҂��ăt���O�𗧂Ă�
            {
                yield return new WaitForSeconds(1);
                isMax = true;
            }

            if (isMax)i -= add_i;//Min�܂�0.0�P�Â��炷

            c.a = i;
            image.color = c;
            yield return null;

            if (i <= 0 && isMax) loop = true;//i��0�ɂȂ�����While����E�o
        }
    }

    IEnumerator phase_1()
    {
        //���[����Count�C�̓G���o��
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemy_1, enemy1_2_pos, Quaternion.identity);
            yield return new WaitForSeconds(wait_s);

            if (i == next_count) StartCoroutine(phase_2());//  �񓯊��Ŏ��s

        }
    }
    IEnumerator phase_2()
    {

        //�E�[����Count�C�̓G���o��
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemy_2, new Vector2(enemy1_2_pos.x * -1, enemy1_2_pos.y), Quaternion.identity);

            yield return new WaitForSeconds(wait_s);

            if (i == count - 1)//������ƍd���Q�̂̓G���o��
            {
                Instantiate(enemy_3, enemy3_pos, Quaternion.identity).GetComponent<enemy_3>().interval_flag = true;//interval_flag��True�ɂ���

                Instantiate(enemy_3, new Vector2(enemy3_pos.x * -1, enemy3_pos.y), Quaternion.identity);//x���W��-1����Z���ďo��������
            }
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(phase_3());

    }
    IEnumerator phase_3()
    {
        Instantiate(enemy_4, enemy4_pos, Quaternion.identity);

        yield return new WaitForSeconds(2);

        for (int i = 0; i < count; i++)
        {
            Instantiate(enemy_5, new Vector2(enemy1_2_pos.x * -1, enemy1_2_pos.y), Quaternion.identity);//�E�[����Count�C�̓G���o��
            yield return new WaitForSeconds(wait_s);
        }


        yield return new WaitForSeconds(wait_s);
    }




}
