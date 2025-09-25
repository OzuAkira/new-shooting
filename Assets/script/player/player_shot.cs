using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        // 攻撃アクションをPlayerInputから取得
        _shotAction = _playerInput.actions[_slowActionName];
    }
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
                Instantiate(player_bullet, gameObject.transform.position + new Vector3(0,instant_Ypos), Quaternion.identity);//弾を生成
                isShot = true;
            }
        }
        else if(_shotAction == null)
        {
            Debug.Log("_shotAction がNullです！");
            return;
        }
    }

}
