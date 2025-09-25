using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_move : MonoBehaviour
{
    Rigidbody2D rb;//rb.velocityで動かす用
    Vector2 axis;//OnMoveの入力値を保存

    public float moveSpeed = 1;
    private float neutral_Speed , half_Speed;


    
    private PlayerInput _playerInput;// 入力を受け取るPlayerInput
    [SerializeField] private string _slowActionName = "Slow";// アクション名
    private InputAction _slowAction;// アクションのコンポーネント

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _slowAction = _playerInput.actions[_slowActionName];// アクションをPlayerInputから取得
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        neutral_Speed = moveSpeed;//非・低速時の移動速度
        half_Speed = moveSpeed/2;//低速時の移動速度
    }
    void OnMove(InputValue value)
    {
        axis = value.Get<Vector2>();
    }
    private void Update()
    {
        //低速移動のフラグ処理
        if (_slowAction != null)
        {
            // 攻撃ボタンの押下状態取得
            var isPressed = _slowAction.IsPressed();

            if (isPressed)moveSpeed = half_Speed;
            else moveSpeed = neutral_Speed;
        }
        else
        {
            Debug.Log("_slowAction がNullです！");
            return;
        }

        //移動処理
        rb.velocity = new Vector2(axis.x, axis.y) * moveSpeed;
    }
}
