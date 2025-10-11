using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class player_shot : MonoBehaviour
{
    private PlayerInput _playerInput;// 入力を受け取るPlayerInput
    [SerializeField] private string _slowActionName = "Shot";// アクション名
    private InputAction _shotAction;// アクションのコンポーネント

    bool isShot = false;
    int i;
    [SerializeField] int interval = 5;

    private float instant_Ypos = 0.5f;

    [SerializeField] GameObject player_bullet;

    int my_power = 0;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        // 攻撃アクションをPlayerInputから取得
        _shotAction = _playerInput.actions[_slowActionName];
    }
    GameObject score ,power, canvas;
    Text score_text , powre_text;
    public int now_score;
    private void Start()
    {
        canvas = GameObject.Find("Canvas_2");
        score = canvas.transform.Find("score").gameObject;
        power = canvas.transform.Find("power").gameObject;
    }
    int power_level = 12;
    private void Update()
    {
        //間隔でフラグを管理
        if (isShot)
        {
            if (i >= interval)
            {
                i = 0;
                isShot = false;
            }
            else i++;
        }

        //攻撃処理
        if (_shotAction != null && isShot == false)
        {
            // 攻撃ボタンの押下状態取得
            var isPressed = _shotAction.IsPressed();

            if (isPressed)
            {
                if(my_power > power_level*2)
                {
                    Instantiate(player_bullet, gameObject.transform.position + new Vector3(0, instant_Ypos), Quaternion.Euler(0, 0, 1));
                    Instantiate(player_bullet, gameObject.transform.position + new Vector3(0, instant_Ypos), Quaternion.identity);
                    Instantiate(player_bullet, gameObject.transform.position + new Vector3(0, instant_Ypos), Quaternion.Euler(0, 0, -1));
                }
                
                else if(my_power > power_level)
                {
                    Instantiate(player_bullet, gameObject.transform.position + new Vector3(0, instant_Ypos), Quaternion.Euler(0,0,1));
                    Instantiate(player_bullet, gameObject.transform.position + new Vector3(0, instant_Ypos), Quaternion.Euler(0, 0, -1));
                }

                else Instantiate(player_bullet, gameObject.transform.position + new Vector3(0, instant_Ypos), Quaternion.identity);//弾を生成

                isShot = true;
                Debug.Log(my_power);

            }
        }
        else if(_shotAction == null)
        {
            Debug.Log("_shotAction がNullです！");
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            item catch_item = collision.gameObject.GetComponent<item>();
            if (catch_item.isPoint)
            {
                score_text = score.GetComponent<Text>();
                now_score = int.Parse(score_text.text);

                now_score += catch_item.have_point;
                score_text.text = now_score.ToString();
            }
            else
            {
                powre_text = power.GetComponent<Text>();
                my_power += catch_item.have_power;

                powre_text.text = "Power : " + my_power.ToString();

                //scoreも上げる
                score_text = score.GetComponent<Text>();
                now_score = int.Parse(score_text.text);

                now_score += catch_item.have_point;
                score_text.text = now_score.ToString();
            }
            Destroy(collision.gameObject);
        }
    }

}
