using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_shot : MonoBehaviour
{
    private PlayerInput _playerInput;// ���͂��󂯎��PlayerInput
    [SerializeField] private string _slowActionName = "Shot";// �A�N�V������
    private InputAction _shotAction;// �A�N�V�����̃R���|�[�l���g

    bool isShot = false;
    int i;
    [SerializeField] int interval = 5;

    private float instant_Ypos = 0.5f;

    [SerializeField] GameObject player_bullet;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        // �U���A�N�V������PlayerInput����擾
        _shotAction = _playerInput.actions[_slowActionName];
    }
    private void Update()
    {
        //�Ԋu�Ńt���O���Ǘ�
        if (isShot)
        {
            if (i >= interval)
            {
                i = 0;
                isShot = false;
            }
            else i++;
        }

        //�U������
        if (_shotAction != null && isShot == false)
        {
            // �U���{�^���̉�����Ԏ擾
            var isPressed = _shotAction.IsPressed();

            if (isPressed)
            {
                Instantiate(player_bullet, gameObject.transform.position + new Vector3(0,instant_Ypos), Quaternion.identity);//�e�𐶐�
                isShot = true;
            }
        }
        else if(_shotAction == null)
        {
            Debug.Log("_shotAction ��Null�ł��I");
            return;
        }
    }

}
