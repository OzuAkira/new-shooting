using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class stageBoss_1 : MonoBehaviour

//ボスは全ての処理をこのスクリプトで実行する
{
    [SerializeField] float start_y_Pos = 3 , moveSpeed;
    [SerializeField] GameObject HP_slider;

    [SerializeField] GameObject[] phase_1_bullet;

    GameObject playerObj;
    Rigidbody2D rb;
    BoxCollider2D bc;
    Slider slider;int HP = 300;

    bool isSpell = false , isPhase_1 = false;

    System.Random rnd;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        bc.enabled = false;//最初は無敵

        rb = GetComponent<Rigidbody2D>();

        rnd = new System.Random();      // Randomオブジェクトを作成

        playerObj = GameObject.Find("player");

        StartCoroutine(buttleStart());//登場＆無敵解除
    }

    bool stopd = false;
    private void Update()
    {
        if(slider == null)return;
        if(slider.value <= (slider.maxValue / 10) * 3)//現HPが残り3割になったら
        {
            if (stopd == false)
            { 
                StopAllCoroutines();
                stopd = true;
                StartCoroutine(spell_1());
            }
            
        }
    }

    //被弾処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player_bullet"))
        {
            
            Destroy(collision.gameObject);
            HP--;
            if(isPhase_1) slider.value = HP- slider.maxValue * 2;

        }
    }

    
    IEnumerator buttleStart()
    {
        //下に降りてくるやつ
        while (gameObject.transform.position.y > start_y_Pos)
        {
            Vector2 pos = gameObject.transform.position - new Vector3(0,moveSpeed,0);
            rb.MovePosition(pos);

            yield return null;
        }

        yield return new WaitForSeconds(2);

        GameObject _hp = Instantiate(HP_slider);//HPバーを表示
        slider = _hp.transform.Find("Slider").GetComponent<Slider>();//sliderを取得
        slider.value = HP;//HPを初期化

        bc.enabled = true;//当たり判定をture


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

            frame_1++;//移動後に撃つ処理
            if (frame_1 == shotFrame)yield return StartCoroutine(circleShot());
            if(frame_1 == shotFrame*2) StartCoroutine(circleShot());
            if(frame_1 == shotFrame * 3)yield return StartCoroutine(circleShot());
            if (frame_1 == shotFrame * 4)
            {
                StartCoroutine(circleShot());
                frame_1 = 0;//元に戻す（x=0）
            }

            yield return null;  
        }
    }
    public List<Vector2> Raw_eimPos;
    IEnumerator eimShot_1()
    {
        while (true)
        {
            List<Vector2> clonePos = new List<Vector2>(Raw_eimPos);//コピー

            int rand_n = rnd.Next(clonePos.Count/2, clonePos.Count);
            for (int i = 0; i < rand_n; i++)
            {
                int rand_index = rnd.Next(0, clonePos.Count);//インデックスをランダムに生成
                Instantiate(phase_1_bullet[1], clonePos[rand_index], Quaternion.identity);//ランダムな座標に自機狙い弾を生成
                clonePos.RemoveAt(rand_index);//使用したインデックスを削除
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

        float _ = rnd.Next(0, 2);//第一引数以上、第二引数未満

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
    IEnumerator spell_1()
    {
        bc.enabled = false;//当たり判定を消す

        

        Vector3 velocity = spell_myPos - gameObject.transform.position;//ベクトルを計算
        bool right = false;

        if(velocity.x > 0)right = true;//進行方向が右（X方向のベクトルが正の値）の場合はtrue
        //定位置まで移動
        while (gameObject.transform.position != spell_myPos)
        {
            
            Vector3 movePos = gameObject.transform.position + velocity * spell_1_moveSpeed;

            if (right && movePos.x > 0) movePos = spell_myPos;//矯正
            if (right == false && movePos.x < 0) movePos = spell_myPos;//矯正

            rb.MovePosition(movePos);

            yield return null;
        }
        
        //ここからスペルカードの弾幕を書く

    }
    }

