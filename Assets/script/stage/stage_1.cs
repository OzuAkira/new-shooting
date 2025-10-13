using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class stage_1 : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image image;

    public GameObject enemy_1, enemy_2, enemy_3, enemy_4 , enemy_5 , enemy_6 , enemy_7 ,boss;
    public Vector2 enemy1_2_pos, enemy3_pos, enemy4_pos , enemy7_pos , boss_Pos;

    int count = 10;

    int next_count = 8;
    [SerializeField]float wait_s = 1f;
    [SerializeField] GameObject bomBody;
    List<GameObject> keyEnemies = new List<GameObject>();//�|���Ȃ��Ɛ�ɐi�߂Ȃ�

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
        //�E�[�ɒe����Ob����z�u
        GameObject bom = Instantiate(bomBody, new Vector3(8, 0), Quaternion.identity);

        //���[����Count�C�̓G���o��
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemy_1, enemy1_2_pos, Quaternion.identity);
            yield return new WaitForSeconds(wait_s);

            if (i == next_count) StartCoroutine(phase_2());//  �񓯊��Ŏ��s

        }
        Destroy(bom);
    }
    IEnumerator phase_2()
    {
        GameObject bom = Instantiate(bomBody, new Vector3(-8, 0), Quaternion.identity);
        //�E�[����Count�C�̓G���o��
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemy_2, new Vector2(enemy1_2_pos.x * -1, enemy1_2_pos.y), Quaternion.identity);

            yield return new WaitForSeconds(wait_s);

            if (i == count - 1)//������ƍd���Q�̂̓G���o��
            {
                GameObject wallShot_enemy_1 = Instantiate(enemy_3, enemy3_pos, Quaternion.identity);
                wallShot_enemy_1.GetComponent<enemy_3>().interval_flag = true;//interval_flag��True�ɂ���

                keyEnemies.Add(wallShot_enemy_1);//�����͓|���Ȃ��ƃ{�X���o�����Ȃ�

                GameObject wallShot_enemy_2 = Instantiate(enemy_3, new Vector2(enemy3_pos.x * -1, enemy3_pos.y), Quaternion.identity);//x���W��-1����Z���ďo��������

                keyEnemies.Add (wallShot_enemy_2);//�����͓|���Ȃ��ƃ{�X���o�����Ȃ�
            }
        }
        Destroy(bom);
        yield return new WaitForSeconds(1);
        StartCoroutine(phase_3());

    }
    IEnumerator phase_3()
    {
        GameObject middle_enemy1 = Instantiate(enemy_4, enemy4_pos, Quaternion.identity);//�e���V�����������

        yield return new WaitForSeconds(2);

        GameObject bom = Instantiate(bomBody, new Vector3(-8, 0), Quaternion.identity);
        while (middle_enemy1 != null)
        {
            Instantiate(enemy_5, new Vector2(enemy1_2_pos.x * -1, enemy1_2_pos.y), Quaternion.identity);//�E�[����Count�C�̓G���o��
            yield return new WaitForSeconds(4);
        }
        Destroy (bom);

        GameObject middle_enemy2 = Instantiate(enemy_4, new Vector2( -enemy4_pos.x , enemy4_pos.y), Quaternion.identity);//�e���V�����������2���B���Α�����o��

        GameObject circlShot_enemy = Instantiate(enemy_7 , enemy7_pos , Quaternion.identity);//360�x���z
        enemy_death death = circlShot_enemy.GetComponent<enemy_death>();

        keyEnemies.Add(circlShot_enemy);//�����͓|���Ȃ��ƃ{�X���o�����Ȃ�

        yield return new WaitForSeconds(wait_s);

        bom = Instantiate(bomBody, new Vector3(8, 0), Quaternion.identity);
        while (middle_enemy2 != null)
        {
            death.hpStoper = true;
            Instantiate(enemy_6, enemy1_2_pos, Quaternion.identity);//���[����Count�C�̓G���o��
            yield return new WaitForSeconds(4);
        }
        Destroy(bom);

        death.hpStoper = false;
        yield return new WaitForSeconds(wait_s);

        while (true)
        {
            if (keyEnemies.All(enemy => enemy == null))//keyEnemies���S�ẴI�u�W�F�N�g��null��������
                break;

            yield return null;
        }
        yield return new WaitForSeconds(3);

        Instantiate(boss, boss_Pos, Quaternion.identity);
    }
    



}
