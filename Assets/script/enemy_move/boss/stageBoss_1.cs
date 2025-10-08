using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class stageBoss_1 : MonoBehaviour

//�{�X�͑S�Ă̏��������̃X�N���v�g�Ŏ��s����
//�������AUI�͏���
{
    [SerializeField] float start_y_Pos = 3 , moveSpeed;
    [SerializeField] GameObject HP_slider;

    [SerializeField] GameObject[] phase_1_bullet;

    GameObject playerObj , bom;
    Rigidbody2D rb;
    BoxCollider2D bc;
    Slider slider;float HP = 300;

    bool isSpell = false , isPhase_1 = false , isPhase_2 = false;

    System.Random rnd;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        bc.enabled = false;//�ŏ��͖��G

        rb = GetComponent<Rigidbody2D>();

        rnd = new System.Random();      // Random�I�u�W�F�N�g���쐬

        playerObj = GameObject.Find("player");

        bom = Instantiate(bom_obj);

        

        StartCoroutine(buttleStart());//�o�ꁕ���G����
    }

    bool stopd = false;

    private void Update()
    {
        if(slider == null)return;
        if(slider.value <= (slider.maxValue / 10) * 3)//��HP���c��3���ɂȂ�����
        {
            if (stopd == false)
            { 
                StopAllCoroutines();
                stopd = true;
                StartCoroutine(spell_1());
            }
            
        }
    }

    //��e����
    float spell_damage = 0.5f;
    public List<GameObject> nextHP = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player_bullet"))
        {
            
            Destroy(collision.gameObject);
            if (isSpell) HP -= spell_damage;
            else HP--;



            if (isPhase_1) slider.value = HP - slider.maxValue * 2;
            else if (isPhase_2) slider.value = HP - slider.maxValue;
            if (slider.value <= 0 && isPhase_1)
            {
                bom.SetActive(true);//�S�G�e������

                StopAllCoroutines();//�R���[�`����S�Ē�~

                isPhase_1 = false;//�A���Ăт�h�~
                Debug.Log("hp_image");
                Image HP_0_image = nextHP[0].GetComponent<Image>();
                UnityEngine.Color c = HP_0_image.color;
                c = new Color(0.1509f,0.1309f,0.1217f);//�F���w��
                HP_0_image.color = c;//�T����HP�o�[��1���ɂ���

                slider.value = slider.maxValue;//slider ��Max�ɖ߂�
                bc.enabled = false;//�����蔻���������

                StartCoroutine(phase_2());
            }
        }
    }

    
    IEnumerator buttleStart()
    {
        //���ɍ~��Ă�����
        while (gameObject.transform.position.y > start_y_Pos)
        {
            Vector2 pos = gameObject.transform.position - new Vector3(0,moveSpeed,0);
            rb.MovePosition(pos);

            yield return null;
        }

        yield return new WaitForSeconds(2);

        GameObject _hp = Instantiate(HP_slider);//HP�o�[��\��

        int nextHP_count = 2;
        for (int i = 1; i <= nextHP_count; i++)//����HP�o�[�̃I�u�W�F�N�g���擾
        {
            nextHP.Add(_hp.transform.GetChild(i).gameObject);
        }
        //�����Ƃŏ���
        //nextHP[0].SetActive(false);

        slider = _hp.transform.Find("Slider").GetComponent<Slider>();//slider���擾
        slider.value = HP;//HP��������

        bc.enabled = true;//�����蔻���ture


        isPhase_1 = true;
        StartCoroutine(phase_1());
    }

    int frame_1 = 0 , shotFrame = 158;

    IEnumerator phase_1()
    {
        float xPos , i_1=0 , add_i =0.01f ;

        
        StartCoroutine(circleShot());

        yield return new WaitForSeconds(2);

        StartCoroutine(eimShot_1());

        while (true)
        {
            xPos = math.sin(i_1);
            i_1 += add_i;

            Vector2 pos = new Vector3(xPos*2, gameObject.transform.position.y, 0);
            rb.MovePosition (pos);

            frame_1++;//�ړ���Ɍ�����
            if (frame_1 == shotFrame)yield return StartCoroutine(circleShot());
            if(frame_1 == shotFrame*2) StartCoroutine(circleShot());
            if(frame_1 == shotFrame * 3)yield return StartCoroutine(circleShot());
            if (frame_1 == shotFrame * 4)
            {
                StartCoroutine(circleShot());
                frame_1 = 0;//���ɖ߂��ix=0�j
            }

            yield return null;  
        }
    }
    public List<Vector2> Raw_eimPos;
    IEnumerator eimShot_1()
    {
        while (true)
        {
            List<Vector2> clonePos = new List<Vector2>(Raw_eimPos);//�R�s�[

            int rand_n = rnd.Next(clonePos.Count/2, clonePos.Count);
            for (int i = 0; i < rand_n; i++)
            {
                int rand_index = rnd.Next(0, clonePos.Count);//�C���f�b�N�X�������_���ɐ���
                Instantiate(phase_1_bullet[1], clonePos[rand_index], Quaternion.identity);//�����_���ȍ��W�Ɏ��@�_���e�𐶐�
                clonePos.RemoveAt(rand_index);//�g�p�����C���f�b�N�X���폜
                yield return new WaitForSeconds(1);
            }

            yield return new WaitForSeconds(2);
        }
    }
    
    IEnumerator circleShot()
    {

        int circleNum = 45;
        float addAngle = 4;

        float ms_1 = 0.05f, ms_2 = 0.1f;

        float _ = rnd.Next(0, 2);//�������ȏ�A����������

        if (_ == 0)
        {
            for (int i = 0; i < circleNum; i++)
            {
                Straight_move straight_Move = Instantiate(phase_1_bullet[0], gameObject.transform.position, Quaternion.Euler(0, 0, i * 8))
                    .GetComponent<Straight_move>();
                straight_Move.moveSpeed = ms_1;
            }
            yield return new WaitForSeconds(0.25f);

            for (int i = 0; i < circleNum; i++)
            {
                Straight_move straight_Move = Instantiate(phase_1_bullet[0], gameObject.transform.position, Quaternion.Euler(0, 0, i * 8 + addAngle))
                    .GetComponent<Straight_move>();
                straight_Move.moveSpeed = ms_2;
            }
            yield return new WaitForSeconds(3);
        }
        else
        {
            for (int i = 0; i < circleNum; i++)
            {
                Straight_move straight_Move = Instantiate(phase_1_bullet[0], gameObject.transform.position, Quaternion.Euler(0, 0, i * 8 + addAngle))
                    .GetComponent<Straight_move>();
                straight_Move.moveSpeed = ms_1;
            }
            yield return new WaitForSeconds(0.25f);

            for (int i = 0; i < circleNum; i++)
            {
                Straight_move straight_Move = Instantiate(phase_1_bullet[0], gameObject.transform.position, Quaternion.Euler(0, 0, i * 8))
                    .GetComponent<Straight_move>();
                straight_Move.moveSpeed = ms_2;
            }
            yield return new WaitForSeconds(3);
        }
    }

    Vector3 spell_myPos = new Vector3(0, 3, 0);
    float spell_1_moveSpeed = 0.01f;

    public GameObject eim_bullet ,eim_bullet_2, wave_bullet;

    IEnumerator spell_1()
    {
        yield return StartCoroutine(spell_Anime());
        Debug.Log("spell_anime");
        //��������X�y���J�[�h�̒e��������
        while (true)
        {
            Instantiate(wave_bullet, transform.position, quaternion.identity);
            Instantiate(wave_bullet, transform.position, quaternion.identity).GetComponent<waveBullet>().isMinus = true;

            Instantiate(eim_bullet, transform.position, quaternion.identity);
            Instantiate(eim_bullet, transform.position, quaternion.identity).GetComponent<big_eim>().minus = true;

            yield return new WaitForSeconds(4);

            Instantiate(eim_bullet_2, transform.position, quaternion.identity);
            Instantiate(eim_bullet_2, transform.position, quaternion.identity).GetComponent<big_eim>().minus = true;
            yield return new WaitForSeconds(6);
        }

    }
    public GameObject enemy_image , bom_obj;
    IEnumerator spell_Anime()
    {
        bc.enabled = false;//�����蔻�������
        isSpell = true;

        
        yield return null;
        bom.SetActive(true);

        Vector3 velocity = spell_myPos - gameObject.transform.position;//�x�N�g�����v�Z
        bool right = false;
        if (velocity.x > 0) right = true;//�i�s�������E�iX�����̃x�N�g�������̒l�j�̏ꍇ��true

        GameObject Animetion_obj = Instantiate(enemy_image);//UI�A�j���[�V�������Đ��i�X�y���J�[�h���j

        //��ʒu�܂ňړ�
        while (gameObject.transform.position != spell_myPos)
        {


            Vector3 movePos = gameObject.transform.position + velocity * spell_1_moveSpeed;

            if (right && movePos.x > 0) movePos = spell_myPos;//����
            if (right == false && movePos.x < 0) movePos = spell_myPos;//����

            rb.MovePosition(movePos);

            yield return null;
        }

        spell_animetion sa = Animetion_obj.transform.Find("enemy_image").gameObject.GetComponent<spell_animetion>();
        //UI�A�j���[�V�������Đ����ꂽ��E�o
        while (sa.finish == false)
        {
            sa = Animetion_obj.transform.GetChild(0).gameObject.GetComponent<spell_animetion>();
            yield return null;
        }

        Destroy(Animetion_obj);
        bom.SetActive(false);

        bc.enabled = true;//�����蔻��𕜊�

    }
    public GameObject[] phase2_bullets;
    IEnumerator phase_2()
    {
        yield return new WaitForSeconds(3);

        bc.enabled = true;//�����蔻�����

        bom.SetActive(false);
        isPhase_2 = true;

        float x_pos = 0 , y_pos = 0 , sin_i = 0 , add_i=0.0001f;
        float sum_vect = 0;
        Vector3 goale_pos = new Vector3(-4, -1.5f, 0);
        //Vector3 goale_vect = transform.position - goale_pos;
        while (transform.position != new Vector3(-4, 1.5f, 0))
        {
            
            rb.MovePosition(gameObject.transform.position + goale_pos * sum_vect);

            if (transform.position.x < -4) gameObject.transform.position = new Vector3(-4 , 1.5f,0);
            else sum_vect += add_i;
            yield return null;

        }

        goale_pos = new Vector3(4, 0.75f, 0);
        sum_vect = 0;

        add_i = 0.0001f;
        int i = 0;
        yield return new WaitForSeconds(1);

        System.Random random = new System.Random();
        int loop_count = 3;

        while (transform.position != new Vector3(4, 3f, 0))
        {

            rb.MovePosition(gameObject.transform.position + goale_pos * sum_vect);

            if (transform.position.x > 4) gameObject.transform.position = new Vector3(4, 3, 0);
            else sum_vect += add_i;

            i++;
            if (i % 8 == 0)
            {
                for (int j = 0; j < loop_count; j++)
                {
                    int ran_int = random.Next(-25, 25);
                    int ran_speed = random.Next(3, 10);

                    Instantiate(phase2_bullets[1], transform.position, Quaternion.Euler(0, 0, (i / 8) + ran_int))
                        .GetComponent<Straight_move>().moveSpeed = ran_speed * 0.01f;
                }
            }
            yield return null;

        }
        yield return new WaitForSeconds(1);

        goale_pos = new Vector3(-1, 0, 0);
        sum_vect = 0;

        add_i = 0.0001f;

        bool shoted = false;
        while (transform.position != new Vector3(0, 3f, 0))
        {

            rb.MovePosition(gameObject.transform.position + goale_pos * sum_vect);

            if (transform.position.x <= 2 && shoted == false)
            {
                shoted = true;
                Instantiate(phase2_bullets[2], gameObject.transform.position, Quaternion.identity);//���@�_���̊g�U�e
                                                                                                   //�g����EX�̒��{�X�|��������ɗd���������Ă���A�� ���ꔭ
            }
            if (transform.position.x < 0) gameObject.transform.position = new Vector3(0, 3, 0);
            else sum_vect += add_i;

            yield return null;

        }
        int gravity_int = 50;

        for(int ii = 0; ii < gravity_int; ii++)
        {
           Instantiate(phase2_bullets[3] , transform.position ,Quaternion.identity);

            yield return null; yield return null;//2frame�҂�
        }

    }





}

